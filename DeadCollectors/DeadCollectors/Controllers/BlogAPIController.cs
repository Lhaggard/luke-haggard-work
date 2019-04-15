using DeadCollectors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeadCollectors.Controllers{
    public class BlogAPIController : ApiController{
        private BlogRepository _repo = new BlogRepository();

        [Route("posts/search/{category}/{term}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(string category, string term) {
            // If the user leaves the category search in the "All" state, convert
            // the string to an empty string so the database sproc can take advantage
            // of using a LIKE function on an empty string to return all categories.
            if (category == "all") category = "";
            if (term == "all") term = "";

            return Ok(_repo.SearchPosts(category, term));
        }
    }
}
