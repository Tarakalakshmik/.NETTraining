using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using CC10.Models;
using Swashbuckle.Swagger;
namespace CC10.Controllers
{
    [RoutePrefix("api/Country")]
    public class CountryController : ApiController
    {
      
        // GET: Country
        //public ActionResult Index()
        //{
        //    return View();
        //}
        static List<Country> countries = new List<Country>
        {
            new Country { ID = 1, CountryName = "India", Capital = "New Delhi" },
            new Country { ID = 2, CountryName = "Japan", Capital = "Tokyo" }
        };
        [Route("All")]
        public IHttpActionResult Get()
        {
            return Ok(countries);
        }
        [Route("Byid")]
        public IHttpActionResult Get(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();
            return Ok(country);
        }

        [Route("Post")]
        public IEnumerable<Country> Post([FromBody] Country country)
        {

            countries.Add(country);
            return countries;
        }

        [Route("Put")]
        public IHttpActionResult Put(int id, [FromBody] Country updated)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            country.CountryName = updated.CountryName;
            country.Capital = updated.Capital;

            return Ok(country);
        }

        [Route("Delete")]
        public IHttpActionResult Delete(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            countries.Remove(country);
            return Ok();
        }
    }
}




   