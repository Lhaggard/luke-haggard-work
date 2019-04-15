
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using ADOFirstDvdLibrary.Repository;
using ADOFirstDvdLibrary.Interface;

namespace dvdLibraryAPI.Factorys
{
    public static class DataFactory
    {
        public static IDvdRepository Get()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "SampleData":
                     return new DvdRepositoryMock();
                case "EntityFramework":
                    return new DvdRepositoryEF();
                case "ADO":
                    return new DvdRepositoryADO();
                default:
                    return new DvdRepositoryMock();
                    //I would have just left out the sample data part of this and left it as default but the assignment said to set ups a SampleData case.
            }
        }
    }
}