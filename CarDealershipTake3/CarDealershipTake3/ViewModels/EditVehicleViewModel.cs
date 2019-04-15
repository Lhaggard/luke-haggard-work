using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTake3.ViewModels
{
    public class EditVehicleViewModel
    {
        public Vehicle Vehicle { get; set; }
        public List<VModel> Models { get; set; }
        public List<VMake> Makes { get; set; }
        public List<Body> Body { get; set; }
        public List<Interior> Interior { get; set; }
        public List<Exterior> Color { get; set; }
    }
}