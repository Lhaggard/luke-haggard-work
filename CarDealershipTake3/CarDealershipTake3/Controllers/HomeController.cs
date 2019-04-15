using Data.Factorys;
using Data.Interfaces;
using System;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CarDealershipTake3.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : Controller
    {
        private ICarDealershipRepository _carRepository = DataFactory.Get();

        [HttpGet]
           public ActionResult Index()
        {
            var model = _carRepository.GetFeaturedVehicles();
            return View(model);
        }

        [HttpGet]
        public ActionResult Specials()
        {
            var model = _carRepository.GetSpecails();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _carRepository.GetVehicle(id);

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /*
        [Route("home/index")]
        [AcceptVerbs("GET")]
        public void GetFeatured()
        {
            //get featured will go here  _carRepository.;
            throw new NotImplementedException();

        }
        [Route("home/specials")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSpecials()
        {
            // return Ok(_carRepository.GetSpecails());
            throw new NotImplementedException();
        }
        */
    }
}