using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ADOFirstDvdLibrary.Models.EF
{
    public class Rating
    {
        public string RatingValue { get; set; }
        public int RatingId { get; set; }
    }
}