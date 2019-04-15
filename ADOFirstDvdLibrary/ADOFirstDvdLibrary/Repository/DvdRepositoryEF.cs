using ADOFirstDvdLibrary.Interface;
using ADOFirstDvdLibrary.Models;
using ADOFirstDvdLibrary.Models.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ADOFirstDvdLibrary.Repository
{
    public class DvdRepositoryEF : IDvdRepository
    {


        private static List<Dvd> _dvds;
        DvdLibraryEntities context = new DvdLibraryEntities();
        public void Create(Dvd dvd)
        {
            DvdEF d = new DvdEF
            {
                Notes = dvd.Notes,
                Title = dvd.Title,
                ReleaseYear = dvd.ReleaseYear,
                DvdId = dvd.DvdId
                
            };
            d.Director = new Director { DirectorName = dvd.DirectorName};
            d.Rating = new Rating {RatingValue = dvd.RatingValue };
            context.Dvd.Add(d);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dvd = context.Dvd.Where(b => b.DvdId == id);
            context.Dvd.Remove(dvd.FirstOrDefault(d => d.DvdId == id));
            context.SaveChanges();
        }

        public Dvd Get(int id)
        {
            var dvd = context.Dvd.FirstOrDefault(d => d.DvdId == id);
            return HelperSingle(dvd);
        }

        public List<Dvd> GetByDirectorName(string directorName)
        {
            var director = context.Director.Where(d => d.DirectorName == directorName).Select(x => x.DirectorId).FirstOrDefault();
            var dvd = context.Dvd.Where(d => d.Director.DirectorId == director);
            return Helper(dvd);
        }

        public List<Dvd> GetByRating(string ratingValue)
        {
            var rating = context.Rating.Where(d => d.RatingValue == ratingValue).Select(x => x.RatingId).FirstOrDefault();
            var dvd = context.Dvd.Where(d => d.Rating.RatingId == rating);
            return Helper(dvd);
        }

        public List<Dvd> GetByReleaseYear(int releaseYear)
        {
            var dvd = context.Dvd.Where(d => d.ReleaseYear == releaseYear);
            return Helper(dvd);
        }

        public List<Dvd> GetByTitle(string title)
        {
            var matches = from m in context.Dvd
                          where m.Title.Contains(title)
                          select m;

            return Helper(matches);
        }

        public void Update(Dvd dvd)
        {
            DvdEF d = new DvdEF
            {
                Notes = dvd.Notes,
                Title = dvd.Title,
                ReleaseYear = dvd.ReleaseYear,
                DvdId = dvd.DvdId
            };
            d.Director = new Director { DirectorName = dvd.DirectorName };
            d.Rating = new Rating { RatingValue = dvd.RatingValue };
            var result = context.Dvd.SingleOrDefault(b => b.DvdId == dvd.DvdId);
            if (result != null)
            {
                result = d;
                context.SaveChanges();
            }
        }
        public List<Dvd> GetAll()
        {
           return Helper(context.Dvd);
        }
        public List<Dvd> Helper(IQueryable<DvdEF> _dvdEF)
        {
            //this is used to convert from dvd to dvdEF because the intervace wants dvds and not dvdEFs
            List<Dvd> _dvds = new List<Dvd>();

            if (_dvdEF.Count() > 0)
            {
                foreach (var dvdEF in _dvdEF.ToList())
                {
                    Dvd dvd = new Dvd
                    {
                        DvdId = dvdEF.DvdId,
                        Title = dvdEF.Title,
                        DirectorName = dvdEF.Director.DirectorName,
                        ReleaseYear = dvdEF.ReleaseYear,
                        RatingValue = dvdEF.Rating.RatingValue,
                        Notes = dvdEF.Notes

                    };
                    _dvds.Add(dvd);
                }
            }
            return _dvds;
        }

        public Dvd HelperSingle(DvdEF dvdEF)
        {
            //this is used to convert from dvd to dvdEF because the intervace wants dvds and not dvdEFs
            Dvd dvds = new Dvd();

                    Dvd dvd = new Dvd
                    {
                        DvdId = dvdEF.DvdId,
                        Title = dvdEF.Title,
                        DirectorName = dvdEF.Director.DirectorName,
                        ReleaseYear = dvdEF.ReleaseYear,
                        RatingValue = dvdEF.Rating.RatingValue,
                        Notes = dvdEF.Notes

                    };
                  
            return dvd;
        }


    }

}