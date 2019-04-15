using Data.Interfaces;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Factorys
{
    public static class DataFactory
    {
        public static ICarDealershipRepository Get()
        {
            string mode = ConfigurationManager.AppSettings["mode"].ToString();
            switch (mode)
            {
                case "ADO":
                    return new ADORepository();

                default:
                    return new ADORepository();

            }
        }
    }
}
