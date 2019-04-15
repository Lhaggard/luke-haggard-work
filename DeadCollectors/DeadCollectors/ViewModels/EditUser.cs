using DeadCollectors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeadCollectors.ViewModels {
    public class EditUser {
        public ApplicationUser User { get; set; }
        public string NewRole { get; set; }
        public string NewPassword { get; set; }
    }
}