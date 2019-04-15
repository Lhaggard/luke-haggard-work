using Data.Factorys;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace CarDealershipTake3.Controllers
{
    public class ReportsController : Controller
    {
        private ICarDealershipRepository _carRepository = DataFactory.Get();
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Sales()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Inventory()
        {
            var model = _carRepository.GetInventory();
            return View(model);
        }
    }
}
