using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeadCollectors.Models;

namespace DeadCollectors.ViewModels
{
    public class AboutUsViewModel
    {
        [AllowHtml]
        public AboutUs AboutUsHTML { get; set; }
    }
}