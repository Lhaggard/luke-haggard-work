using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTake3.ViewModels
{
    public class PurchaseViewModel
    {
        public Vehicle Vehicle { get; set; }
        public SalesInformation Sales { get; set; }
        public List<PurchaseType> PType { get; set; }
    }
}