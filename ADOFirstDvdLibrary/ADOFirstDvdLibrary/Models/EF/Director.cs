using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ADOFirstDvdLibrary.Models.EF
{
    public class Director
    {
        [Key]
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
    }
}