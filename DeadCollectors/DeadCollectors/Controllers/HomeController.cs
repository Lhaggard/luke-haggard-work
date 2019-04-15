using DeadCollectors.Models;
using DeadCollectors.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeadCollectors.Controllers {
    public class HomeController : Controller {

        private BlogRepository _repo = new BlogRepository();

        public ActionResult Index() {
            BlogIndexViewModel blogIndexViewModel = new BlogIndexViewModel {
                Posts = _repo.GetThreeMostRecentPosts()
            };
            return View(blogIndexViewModel);
        }

        public ActionResult Custom404() {
            return View();
        }

        public ActionResult AboutUs()
        {
            var model = new AboutUsViewModel()
            {
                AboutUsHTML = _repo.GetAboutUs()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult AboutUs(AboutUsViewModel model)
        {
            return View("EditAboutUs", model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditAboutUs(AboutUsViewModel model)
        {
            if (model.AboutUsHTML is null)
            {
                ModelState.AddModelError("", "The About Us page cannot be empty. Please fill the text area.");

                model.AboutUsHTML = _repo.GetAboutUs();

                return View(model);
            }

            _repo.EditAboutUs(model.AboutUsHTML);

            model.AboutUsHTML = _repo.GetAboutUs();

            return RedirectToAction("AboutUs", "Home", model);
        }
    }
}