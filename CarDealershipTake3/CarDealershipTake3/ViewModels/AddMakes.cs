using CarDealershipTake3.Models;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTake3.ViewModels
{
    public class AddMakes
    {
        public List<VMake> Makes { get; set; }
        public VMake Make { get; set; }
        public ApplicationUser User { get; set; }
    }
}