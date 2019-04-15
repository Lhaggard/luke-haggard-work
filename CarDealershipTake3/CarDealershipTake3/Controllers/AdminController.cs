using CarDealershipTake3.Models;
using CarDealershipTake3.ViewModels;
using Data.Factorys;
using Data.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarDealershipTake3.Controllers
{
    public class AdminController : Controller
    {
        private ICarDealershipRepository _carRepository = DataFactory.Get();
        private static ApplicationDbContext context = new ApplicationDbContext();
        private RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        private UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        private identityFunctions _repoIdent = new identityFunctions();

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Vehicles()
        {
            var model = _carRepository.GetAllAvailableVehicles();
            return View(model);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            EditVehicleViewModel model = new EditVehicleViewModel();
            model.Vehicle = _carRepository.GetVehicle(id);
            model.Makes = _carRepository.GetMakes();
            model.Models = _carRepository.GetModels();
            model.Interior = _carRepository.GetInterior();
            model.Color = _carRepository.GetExteriors();
            model.Body = _carRepository.GetBodys();

            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult CreateSpecial(Special special)
        {
            _carRepository.AddSpecial(special);
            return RedirectToAction("EditSpecials", "Admin");
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult AddSpecial()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult EditSpecials()
        {
            var model = _carRepository.GetSpecails();
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult DeleteSpecial(int Id)
        {
            _carRepository.DeleteSepcial(Id);
            return RedirectToAction("EditSpecials", "Admin");
        }

        [HttpPost]
        public ActionResult UpdateVehicle(Vehicle vehicle)
        {
            _carRepository.UpdateVehicle(vehicle);
            return RedirectToAction("Vehicles", "Admin");
        }

        [HttpPost]
        public ActionResult CreateVehicle(Vehicle vehicle)
        {

            if (vehicle.ImageUpload != null && vehicle.ImageUpload.ContentLength > 0)
            {
                var extensions = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

                var extension = Path.GetExtension(vehicle.ImageUpload.FileName);

                if (!extensions.Contains(extension))
                {
                    ModelState.AddModelError("", "Please upload an image file.");
                };

                //save location
                var savePath = Server.MapPath("~/Images");
                int vehicleId = _carRepository.GetNextInventoryNumber();

                string fileName = $"vehicle-image-id-{vehicleId}";

                var filePath = Path.Combine(savePath, fileName + extension);
                vehicle.ImageUpload.SaveAs(filePath);
                vehicle.PicturePath = Path.GetFileName(filePath);
            }
            _carRepository.AddVehicle(vehicle);
            return RedirectToAction("Vehicles", "Admin");
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult AddVehicle()
        {
            EditVehicleViewModel model = new EditVehicleViewModel();
            model.Vehicle = new Vehicle();
            model.Makes = _carRepository.GetMakes();
            model.Models = _carRepository.GetModels();
            model.Interior = _carRepository.GetInterior();
            model.Color = _carRepository.GetExteriors();
            model.Body = _carRepository.GetBodys();

         
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateMake(VMake make)
        {
            make.AddedBy = System.Web.HttpContext.Current.User.Identity.GetUserName().ToString();
            _carRepository.AddMake(make);
            return RedirectToAction("Makes", "Admin");
        }
        [HttpPost]
        public ActionResult CreateModel(VModel model)
        {
            model.AddedBy = System.Web.HttpContext.Current.User.Identity.GetUserName().ToString();
            _carRepository.AddModel(model);
            return RedirectToAction("Models", "Admin");
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Makes()
        {
            AddMakes model = new AddMakes();


            model.Makes = _carRepository.GetMakes();
            model.Make = new VMake();

            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Models()
        {
            AddModels model = new AddModels();
            model.Makes = _carRepository.GetMakes();
            model.Models = _carRepository.GetModels();
            model.Make = new VMake();
            model.Model = new VModel();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            RegisterViewModel model = new RegisterViewModel();

            return View(model);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult EditUser(string id)
        {
            if (ModelState.IsValid)
            {
                EditUser user = new EditUser();
                user.User = new ApplicationUser();
                user.User = _userManager.FindById(id);
                return View(user);
            }
            else
            {
                return RedirectToAction("Users");
            }
        }

        [HttpPost]
        public async Task<ActionResult> EditUser(EditUser eUser)
        {
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var currentUser = _userManager.FindById(eUser.User.Id);
            List<string> userRoles = _userManager.GetRoles(currentUser.Id).ToList();
            //crashes if null is inserted crashes so added if statment
            //this should only happen during weird things happening during testing but extra protection never hurts
            //and i needed it to find bugs
            if (userRoles.FirstOrDefault() != null)
            {
                string userRole = userRoles.FirstOrDefault();
                _userManager.RemoveFromRole(currentUser.Id, userRole);
            }
            //I am getting a string so im going to search by name
            var userNewRole = _roleManager.FindByName(eUser.NewRole);
            _userManager.AddToRole(currentUser.Id, userNewRole.Name);

            if (eUser.NewPassword != null)
            {
                ChangePassword(currentUser.Id, eUser.NewPassword);
            }

            await _userManager.UpdateAsync(currentUser);
            var ctx = store.Context;
            ctx.SaveChanges();
            return RedirectToAction("Users");
        }

        private void ChangePassword(string userId, string newPassword)
        {
            var user = _userManager.FindById(userId);

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(newPassword);
            PasswordVerificationResult passwordVerificationResult = new PasswordVerificationResult();
            passwordVerificationResult = _userManager.PasswordHasher.VerifyHashedPassword(user.PasswordHash, newPassword);

            _userManager.UpdateSecurityStamp(userId);

            IdentityResult v = _userManager.Update(user);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Users()
        {
            UsersViewModel usersViewModel = new UsersViewModel();
            usersViewModel.Users = _repoIdent.GetUsers();

            return View(usersViewModel);
        }
    }
}
