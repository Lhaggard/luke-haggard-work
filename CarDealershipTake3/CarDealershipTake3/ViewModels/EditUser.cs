using CarDealershipTake3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipTake3.ViewModels

    {
    public class EditUser
    {
        public ApplicationUser User { get; set; }
        public string NewRole { get; set; }
        public string NewPassword { get; set; }

    }
}
