using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Inventory
    {
        public int Year { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Count { get; set; }
        public int StockValue { get; set; }
        public bool IsNew { get; set; }
    }
}
