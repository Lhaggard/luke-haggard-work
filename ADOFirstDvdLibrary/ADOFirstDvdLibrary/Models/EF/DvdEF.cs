using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ADOFirstDvdLibrary.Models.EF
{
    [Table("Dvds")]
    public class DvdEF
    {
        [Key]
        public int DvdId { get; set; }
        public string Title { get; set; }
        public int? ReleaseYear { get; set; }
        public string Notes { get; set; }

        public int DirectorId { get; set; }
        public int RatingId { get; set; }

        public virtual Director Director { get; set; }
        public virtual Rating Rating { get; set; }
    }
}