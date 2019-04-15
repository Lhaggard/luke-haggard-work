using ADOFirstDvdLibrary.Interface;
using ADOFirstDvdLibrary.Models;
using dvdLibraryAPI.Factorys;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ADOFirstDvdLibrary.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {
        private IDvdRepository _dvdRepository = DataFactory.Get();

        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(_dvdRepository.GetAll());
        }
        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int id)
        {
            Dvd found = _dvdRepository.Get(id);

            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }
        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Create(Dvd dvd)
        {
            _dvdRepository.Create(dvd);
            return Created($"dvd/{dvd.DvdId}", dvd);
        }
        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            _dvdRepository.Delete(id);
        }
        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(int id, Dvd dvd)
        {
            _dvdRepository.Update(dvd);
        }
        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("Get")]
        public IHttpActionResult GetByRating(string rating)
        {
            List<Dvd> found = _dvdRepository.GetByRating(rating);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }
        [Route("dvds/title/{title}")]
        [AcceptVerbs("Get")]
        public IHttpActionResult GetByTitle(string title)
        {
            List<Dvd> found = _dvdRepository.GetByTitle(title);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        [Route("dvds/year/{year}")]
        [AcceptVerbs("Get")]
        public IHttpActionResult GetByReleaseyear(int year)

        {
            List<Dvd> found = _dvdRepository.GetByReleaseYear(year);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        [Route("dvds/director/{name}")]
        [AcceptVerbs("Get")]
        public IHttpActionResult GetByDirectorName(string name)
        {
            List<Dvd> found = _dvdRepository.GetByDirectorName(name);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);

        }
    }

}

