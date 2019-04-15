using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadCollectors.Data.Models {
    public class Post {
        public int PostID { get; set; }
        public string UserID { get; set; }
        public string Body { get; set; }
        public DateTime Creation { get; set; }
        public bool IsApproved { get; set; }
        public Category Category { get; set; }
    }
}
