using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarDealershipTake3.Models
{

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("CarDealership", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
       
    }
    public class identityFunctions
    {
        private static ApplicationDbContext context = new ApplicationDbContext();
        private UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        private RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        public string GetRoleName(string userId)
        {

            var role = _userManager.GetRoles(userId).ToList();

            return role.FirstOrDefault();
        }

        public List<ApplicationUser> GetUsers()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;

                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetUsers"
                };

                sqlConnection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        ApplicationUser user = new ApplicationUser
                        {
                            Id = dataReader["Id"].ToString(),
                            Email = dataReader["Email"].ToString()
                        };

                        users.Add(user);
                    }
                }
            }

            return users;
        }
    }
}