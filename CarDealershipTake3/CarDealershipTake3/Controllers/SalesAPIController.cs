using Data.Factorys;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealershipTake3.Controllers
{
    public class SalesAPIController : ApiController
    {
        private ICarDealershipRepository _carRepository = DataFactory.Get();
        [Route("purchase/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetVehicle(int id)
        {
            return Ok(_carRepository.GetVehicle(id));
        }
        [Route("sales/{startDate}/{endDate}/{minPrice}/{maxPrice}/{searchTerm}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModels(int startDate, int endDate, int minPrice, int maxPrice, string searchTerm)
        {
            if (searchTerm == "all")
            {
                searchTerm = "";
            }
            return Ok(_carRepository.SalesSearchVehicles(startDate, endDate, minPrice, maxPrice, searchTerm));
        }

      
    }
    


}
