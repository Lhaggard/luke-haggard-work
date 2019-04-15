using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeadCollectors.Models
{
    public class AboutUs
    {
        [AllowHtml] 
        public string AboutUsHTML { get; set; }
    }
}