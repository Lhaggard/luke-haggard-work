using ADOFirstDvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOFirstDvdLibrary.Interface
{
    public interface IDvdRepository
    {
        Dvd Get(int id);
        List<Dvd> GetAll();
        List<Dvd> GetByTitle(string title);
        List<Dvd> GetByReleaseYear(int releaseYear);
        List<Dvd> GetByDirectorName(string directorName);
        List<Dvd> GetByRating(string ratingValue);
        void Create(Dvd dvd);
        void Update(Dvd dvd);
        void Delete(int id);
    }
}