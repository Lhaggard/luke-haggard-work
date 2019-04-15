using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class EditVehicle
    {
        public Vehicle Vehicle { get; set; }
        public VMake Make { get; set; }
        public VModel Model { get; set; }
        public Body Body { get; set; }
    }
}
