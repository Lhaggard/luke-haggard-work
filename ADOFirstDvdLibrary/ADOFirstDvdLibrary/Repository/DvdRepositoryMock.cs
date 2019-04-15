using ADOFirstDvdLibrary.Interface;
using ADOFirstDvdLibrary.Models;
using ADOFirstDvdLibrary.Models.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ADOFirstDvdLibrary.Repository
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private static List<Dvd> _dvds;
        private static List<Rating> _ratings;
        private static List<Director> _directors;
        static DvdRepositoryMock()
        {
            _ratings = new List<Rating>()
            {
               new Rating {RatingValue="G"},
               new Rating {RatingValue="PG"},
               new Rating {RatingValue="PG-13"},
               new Rating {RatingValue="R"}

            };

            _directors = new List<Director>
            {
                new Director {DirectorName = "Bob Smith"},
                new Director {DirectorName = "Warren Beasous"}
            };


            _dvds = new List<Dvd>()
            {
                new Dvd {Title="A Dvd",DirectorName = "Bob Smith" , ReleaseYear = 2012, Notes="This is a note", RatingValue = "G", DvdId = 1},
                new Dvd {Title="Another Dvd",DirectorName = "Freddy" , ReleaseYear = 2019, Notes="This is a note", RatingValue = "R", DvdId = 2},
                new Dvd {Title="Another Dvd",DirectorName = "Freddy" , ReleaseYear = 2019, Notes="This is a note", RatingValue = "R", DvdId = 3}
            };

        }
        public void Create(Dvd dvd)
        {
            if (_dvds.Any())
            {
                dvd.DvdId = _dvds.Max(d => d.DvdId) + 1;
            }
            else
            {
                dvd.DvdId = 1;
            }

            _dvds.Add(dvd);
        }

        public void Delete(int id)
        {
            _dvds.RemoveAll(d => d.DvdId == id);
        }

        public Dvd Get(int id)
        {
            return _dvds.FirstOrDefault(d => d.DvdId == id);
        }

        public List<Dvd> GetAll()
        {
            return _dvds;
        }

        public List<Dvd> GetByDirectorName(string directorName)
        {
            return _dvds.Where(d => d.DirectorName.Contains(directorName)).ToList();
        }

        public List<Dvd> GetByRating(string ratingValue)
        {
            return _dvds.Where(d => d.RatingValue.Contains(ratingValue)).ToList(); 
        }

        public List<Dvd> GetByReleaseYear(int releaseYear)
        {
            return _dvds.Where(d => d.ReleaseYear == releaseYear).ToList();
        }

        public List<Dvd> GetByTitle(string title)
        {
            return _dvds.Where(d => d.Title.Contains(title)).ToList();
        }

        public void Update(Dvd dvd)
        {
            _dvds.RemoveAll(d => d.DvdId == dvd.DvdId);
            _dvds.Add(dvd);
        }
    }
}