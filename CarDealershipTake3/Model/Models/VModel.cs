using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class VModel
    {
        public string Model { get; set; }
        public string Make { get; set; }
        public int MakdId { get; set; }
        public string AddedBy { get; set; }
        public int ModelId { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
