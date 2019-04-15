using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
    }
}
