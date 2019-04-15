using ADOFirstDvdLibrary.Interface;
using ADOFirstDvdLibrary.Models;
using dvdLibraryAPI.Factorys;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoFirstDvdLibraryTests
{
    [TestFixture]
    public class Tests
    {
        [TestCase(1,"G")]
        [TestCase(2, "R")]
        public void GetDvdTrue(int id,string rating)
        {

            IDvdRepository repo = DataFactory.Get();
            Dvd dvd = repo.Get(id);
            Assert.AreEqual(dvd.RatingValue, rating);
        }

        [TestCase(1, "PG")]
        [TestCase(2, "33")]
        public void GetDvdFalse(int id, string rating)
        {

            IDvdRepository repo = DataFactory.Get();
            Dvd dvd = repo.Get(id);
            Assert.AreNotEqual(dvd.RatingValue, rating);
        }

        [TestCase("Bob Smith")]
        [TestCase("Freddy")]
        public void GetByDirector(string director)
        {

            IDvdRepository repo = DataFactory.Get();
            List<Dvd> dvd = repo.GetByDirectorName(director);
            Assert.AreEqual(dvd.Count, 1);
        }


        [TestCase(3)]
        public void DeleteDvd(int id)
        {

            IDvdRepository repo = DataFactory.Get();
            repo.Delete(id);
            Dvd dvd = repo.Get(id);
            Assert.AreEqual(dvd,null);
        }

        [TestCase(1)]
        public void UpdateDvd(int id)
        {

            IDvdRepository repo = DataFactory.Get();
            Dvd dvd = repo.Get(id);
            dvd.ReleaseYear = 3000;
            repo.Update(dvd);
            Dvd dvdUpdate = repo.Get(id);
            Assert.AreEqual(dvdUpdate.ReleaseYear, 3000);
        }

    }
}
