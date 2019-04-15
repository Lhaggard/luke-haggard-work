using Data.Factorys;
using Data.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace CarDealershipTake3.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdminAPIController : ApiController
    {
        private ICarDealershipRepository _carRepository = DataFactory.Get();

        //[Route("admin/vehicles")]
        //[AcceptVerbs("GET")]
       // public IHttpActionResult GetAll()
        //{
       //     return Ok(_carRepository.GetAllAvailableVehicles());
        //}
       // [Route("admin/addvehicle")]
      //  [AcceptVerbs("POST")]
       /// public IHttpActionResult AddVehicle(Vehicle vehicle)
       // {
         //   _carRepository.AddVehicle(vehicle);
         //  return Created($"vehicle/{vehicle.InventoryNumber}", vehicle);
        //}
        [Route("admin/specials")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            _carRepository.DeleteSepcial(id);
        }

        [Authorize(Roles = "admin")]
        [Route("models/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModels(int id)
        {
           return Ok(_carRepository.GetModelsByMake(id));

        }
        [Authorize(Roles = "admin")]
        [Route("reports/sales/{startDate}/{endDate}/{user}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSalesReport(DateTime startDate, DateTime endDate, string user)
        {
            if (user == "all")
            {
                user = "";
            }
            return Ok(_carRepository.GetSalesByDate(startDate, endDate, user));
        }
    }
}
