using DeadCollectors.Models;
using DeadCollectors.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DeadCollectors.Controllers
{
    public class AdminController : Controller {

        private BlogRepository _repo = new BlogRepository();
        private static ApplicationDbContext context = new ApplicationDbContext();
        private RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        private UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

        [HttpGet]
        public ActionResult Index() {
            return View();
        }
        
        [HttpGet]
        public ActionResult Pending() {
            if (ModelState.IsValid)
            {
                return View(_repo.GetPendingPosts());
            }
            else
                return View("Index");
        }
        
        [HttpGet]
        public ActionResult AddUser() {
            return View();
        }

        [HttpGet]
        public ActionResult EditUser(string id) {
            if (ModelState.IsValid)
            {
                EditUser user = new EditUser();
                user.User = new ApplicationUser();
                user.User = _userManager.FindById(id);
                return View(user);
            }
            else
                return RedirectToAction("Users");
        }

        [HttpPost]
        public async Task<ActionResult> EditUser(EditUser eUser) {
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var currentUser = _userManager.FindById(eUser.User.Id);
            List<string> userRoles = _userManager.GetRoles(currentUser.Id).ToList();
            
            string userRole = userRoles.FirstOrDefault();
            _userManager.RemoveFromRole(currentUser.Id, userRole);

            var userNewRole = _roleManager.FindById(eUser.NewRole);
            _userManager.AddToRole(currentUser.Id, userNewRole.Name);
            
            if (eUser.NewPassword != null) ChangePassword(currentUser.Id, eUser.NewPassword);
            await _userManager.UpdateAsync(currentUser);
            var ctx = store.Context;
            ctx.SaveChanges();
            return RedirectToAction("Users");
        }

        public  ActionResult DeleteUser(string id) {
            ApplicationUser user = new ApplicationUser();

            user = _userManager.FindById(id);
            _userManager.DeleteAsync(user);

            return RedirectToAction("Users");
        }

        public ActionResult Users()
        {
            UsersViewModel usersViewModel = new UsersViewModel();
            usersViewModel.Users = _repo.GetUsers();

            return View(usersViewModel);
        }

        [HttpGet]
        public ActionResult EditPost(int id) {
            Post post = _repo.GetPost(id);
            return View(_repo.GetPost(id));
        }

        [HttpPost]
        public ActionResult EditPost(Post post) {
            post.IsApproved = true;
            _repo.EditPost(post);
            return RedirectToAction("Pending");
        }

        public ActionResult DeletePost(int id) {
            _repo.DeletePost(id);
            return RedirectToAction("Pending");
        }

        public ActionResult ApprovePost(int id) {
            _repo.ApprovePost(id);
            return RedirectToAction("Pending");
        }

        [HttpGet]
        public ActionResult Roles() {
            return View();
        }

        public ActionResult AddRole(string roleName) {
            _roleManager.Create(new IdentityRole(roleName));
            return RedirectToAction("Roles");
        }

        public ActionResult EditRole(string id, string newRoleName) {
            _roleManager.Delete(new IdentityRole(newRoleName));
            _roleManager.Create(_roleManager.FindById(id));
            return RedirectToAction("Roles");
        }

        public ActionResult DeleteRole(string id) {
            _roleManager.Delete(_roleManager.FindById(id));
            return RedirectToAction("Roles");
        }

        private void ChangePassword(string userId, string newPassword) {
            var user = _userManager.FindById(userId);
            
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(newPassword);
            PasswordVerificationResult passwordVerificationResult = new PasswordVerificationResult();
            passwordVerificationResult = _userManager.PasswordHasher.VerifyHashedPassword(user.PasswordHash, newPassword);
            
            _userManager.UpdateSecurityStamp(userId);
            
            IdentityResult v = _userManager.Update(user);
            //if (v.Succeeded) {
            //    //success
            //}
            //else {
            //    //failure. Perhaps Loop through v.Errors to find out why.
            //    //Though, the documentation doesn't provide any hints as to what possible values
            //    //v.Errors may contain (it's an IEnumerable)
            //}
        }
    }
}