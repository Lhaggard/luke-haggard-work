using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DeadCollectors.Models {
    public class Post {
        [Required(ErrorMessage ="Post Id not found")]
        public int PostID { get; set; }
        public ApplicationUser User { get; set; }
        [Required(ErrorMessage ="Post may not be empty")]
        [AllowHtml]
        public string Body { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
        public DateTime Creation { get; set; }
        public bool IsApproved { get; set; }
        [Required(ErrorMessage = "Post must have a category")]
        public Category Category { get; set; }
        public string Photo { get; set; }
    }
}
