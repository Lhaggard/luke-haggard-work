using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DeadCollectors.Models;
using DeadCollectors.ViewModels;

namespace DeadCollectors.Controllers{
    public class BlogController : Controller{

        private BlogRepository _repo = new BlogRepository();
        
        public ActionResult Index()
        {
            var model = new BlogIndexViewModel()
            {
                Posts = _repo.GetApprovedPosts()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult AddPost()
        {
            var model = new Post();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin, publisher")]
        public ActionResult AddPost(Post model) {

            model.IsApproved = User.IsInRole("admin") ? true : false;

            model.User = new ApplicationUser()
            {
                Email = User.Identity.GetUserName()
            };

            if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
            {
                // Required file types
                var extensions = new string[] { ".jpg", ".png", ".gif", ".jpeg"};

                // Get extension of the uploaded file
                var extension = Path.GetExtension(model.ImageUpload.FileName);

                if (!extensions.Contains(extension))
                {
                    ModelState.AddModelError("", "Please upload an image file.");
                };
            }

            if (model.ImageUpload is null)
            {
                ModelState.AddModelError("", "Please upload an image.");
            }

            if (ModelState.IsValid)
            {
                if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                {
                    // Where to save the image files
                    var savePath = Server.MapPath("~/Images");

                    // Number of posts
                    int postID = _repo.GetNextPostID();

                    // Define the file name
                    string fileName = $"post-image-id-{postID}";

                    // Get the file type / extension
                    string extension = Path.GetExtension(model.ImageUpload.FileName);

                    // Build the filepath
                    var filePath = Path.Combine(savePath, fileName + extension);

                    // Save the image file
                    model.ImageUpload.SaveAs(filePath);

                    // Save the file name to the obj
                    model.Photo = Path.GetFileName(filePath);
                }

                _repo.AddPost(model);

                return RedirectToAction("Index", "Blog");
            }

            return View(model);
        }
    }
}