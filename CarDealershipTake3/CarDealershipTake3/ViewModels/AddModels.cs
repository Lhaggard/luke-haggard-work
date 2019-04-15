using CarDealershipTake3.Models;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTake3.ViewModels
{
    public class AddModels
    {
        public List<VMake> Makes { get; set; }
        public VMake Make { get; set; }
        public VModel Model { get; set; }
        public List<VModel> Models {get; set;}
        public ApplicationUser User { get; set; }
    }
}