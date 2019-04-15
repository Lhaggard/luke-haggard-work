using Microsoft.AspNet.Identity.EntityFramework;

namespace DeadCollectors.Migrations
{
    using DeadCollectors.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DeadCollectors.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DeadCollectors.Models.ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
         
            roleManager.Create(new IdentityRole() {Name = "admin"});
            roleManager.Create(new IdentityRole() {Name = "publisher"});

            if (!context.Users.Any(u => u.UserName == "lancelot@knights.com"))
            {
                var user = new ApplicationUser()
                {
                    UserName = "lancelot@knights.com",
                    Email = "lancelot@knights.com"
                };

                userManager.Create(user, "password");

                userManager.AddToRole(user.Id, "publisher");
            }

            if (!context.Users.Any(u => u.UserName == "admin@hotmail.com"))
            {
                var user = new ApplicationUser()
                {
                    UserName = "admin@hotmail.com",
                    Email = "admin@hotmail.com"
                };

                userManager.Create(user, "password");

                userManager.AddToRole(user.Id, "admin");
            }     
        }
    }
}
