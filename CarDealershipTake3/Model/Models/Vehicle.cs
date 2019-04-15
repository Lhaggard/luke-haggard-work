using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;



namespace Model.Models
{
    public class Vehicle
    {
        public int InventoryNumber { get; set; }
        public int Year { get; set; }
        public int SalePrice { get; set; }
        public int MSRP { get; set; }
        public int Mileage { get; set; }

        public string BodyStyle { get; set; }
        public string VIN { get; set; }
        public string Description { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string InteriorColor { get; set; }
        public string ExteriorColor { get; set; }
        public string PicturePath { get; set; }

        public bool IsManual { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsSold { get; set; }

        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
