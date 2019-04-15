using CarDealershipTake3.ViewModels;
using Data.Factorys;
using Data.Interfaces;
using Model.Models;
using System;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CarDealershipTake3.Controllers
{
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public class InventoryController : Controller
    {
        private ICarDealershipRepository _carRepository = DataFactory.Get();

        [HttpGet]
        public ActionResult New()
        {
            string filterBy = "";
            var model = _carRepository.GetNewVehicles(filterBy);
            return View(model);
        }

        [HttpGet]
        public ActionResult Used()
        {
            string filterBy = "";
            var model = _carRepository.GetUsedVehicles(filterBy);
            return View(model);
        }

        [HttpGet]
        public ActionResult Purchase(int id)
        {
            var model =  new PurchaseViewModel();
            model.Vehicle = _carRepository.GetVehicle(id);
            model.PType = _carRepository.GetPurchaseTypes();
            model.Sales = new SalesInformation();
            return View(model);
        }

  
    }
}
