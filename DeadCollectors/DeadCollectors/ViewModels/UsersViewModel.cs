using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeadCollectors.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeadCollectors.ViewModels
{
    public class UsersViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
