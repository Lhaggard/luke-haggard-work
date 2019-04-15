using CarDealershipTake3.ViewModels;
using Data.Factorys;
using Data.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace CarDealershipTake3.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SalesController : Controller
    {
        private ICarDealershipRepository _carRepository = DataFactory.Get();

        [HttpGet]
        public ActionResult Index()
        {
            var model = _carRepository.GetAllAvailableVehicles();
            return View(model);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = _carRepository.GetVehicle(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Purchase(PurchaseViewModel sale)
        {
            sale.Sales.InventoryNumber = sale.Vehicle.InventoryNumber;
            sale.Sales.SoldBy = System.Web.HttpContext.Current.User.Identity.GetUserName().ToString();
            _carRepository.AddSale(sale.Sales);
            return RedirectToAction("Index", "Sales");
        }
    }
}
