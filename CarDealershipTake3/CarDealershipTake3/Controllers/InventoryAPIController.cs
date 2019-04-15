using Data.Factorys;
using Data.Interfaces;
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
    public class InventoryAPIController : ApiController
    {
        private ICarDealershipRepository _carRepository = DataFactory.Get();

        [Route("inventory/{startDate}/{endDate}/{minPrice}/{maxPrice}/{isNew}/{searchTerm}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModels(int startDate, int endDate, int minPrice, int maxPrice, string isNew, string searchTerm)
        {
            bool newUsed = true;
            if(isNew == "false")
            {
                newUsed = false;
            }
            if(searchTerm == "all")
            {
                searchTerm = "";
            }
            return Ok(_carRepository.SearchVehicles(startDate, endDate, minPrice, maxPrice, newUsed, searchTerm));
        }
    }
}
