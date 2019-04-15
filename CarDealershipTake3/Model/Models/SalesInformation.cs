using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class SalesInformation
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string StateId { get; set; }
        public string Zipcode { get; set; }
        public int PurchasePrice { get; set; }
        public string PurchaseType { get; set; }
        public string SoldBy { get; set; }
        public int VehicleSoldId { get; set; }
        public int InventoryNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
