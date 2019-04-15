namespace CarDealershipTake3.Migrations
{
    using CarDealershipTake3.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static CarDealershipTake3.Models.ApplicationDbContext;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealershipTake3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealershipTake3.Models.ApplicationDbContext context)
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            roleManager.Create(new IdentityRole() { Name = "admin" });
            roleManager.Create(new IdentityRole() { Name = "sales" });
            roleManager.Create(new IdentityRole() { Name = "disabled" });

            if (!context.Users.Any(u => u.UserName == "admin@admin.com"))
            {
                var user = new ApplicationUser()
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };
                userManager.Create(user, "Test123!");

                userManager.AddToRole(user.Id, "admin");
            }

            if (!context.Users.Any(u => u.UserName == "sales@sales.com"))
            {
                var user = new ApplicationUser()
                {
                    UserName = "sales@sales.com",
                    Email = "sales@sales.com"
                };
                userManager.Create(user, "Test123!");

                userManager.AddToRole(user.Id, "sales");
            }


        }
    }
}
