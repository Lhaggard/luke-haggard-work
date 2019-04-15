using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ADOFirstDvdLibrary.Models.EF
{
    public class DvdLibraryEntities : DbContext
    {
        public DvdLibraryEntities() : base(ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString)
        {
        }
        
        //uses dvdEF not dvd because it is used to make the tables for the EF
        public DbSet<DvdEF> Dvd { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Rating> Rating { get; set; }
    }
}