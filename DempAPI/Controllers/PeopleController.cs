using DempAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace DempAPI.Controllers
{
    /// <summary>
    /// This is where I give you all the information about my people
    /// </summary>
    public class PeopleController : ApiController
    {
        List<person> people = new List<person>();
        public PeopleController()
        {
            people.Add(new person { FirstName = "Andreson", LastName = "Corey", Id = 1});
            people.Add(new person { FirstName = "Jayanth", LastName = "Kumar", Id = 2});
            people.Add(new person { FirstName = "Trijal", LastName = "K", Id = 3});
            people.Add(new person { FirstName = "Virat", LastName = "Kohli", Id = 4});
            people.Add(new person { FirstName = "AB", LastName = "D", Id = 5});
            people.Add(new person { FirstName = "yuzi", LastName = "Chahal", Id = 6});
        }

        /// <summary>
        /// Gets a list of the first names of all users.
        /// </summary>
        /// <returns>Returns a list of first names...</returns>
        [Route("api/People/GetFirstNames")]
        [HttpGet]
        public List<string> GetFirstNames()
        {
            List<string> output = new List<string>();
            foreach(var p in people)
            {
                output.Add(p.FirstName);
            }
            return output;
        }

        /// <summary>
        /// API to return list of person.
        /// </summary>
        /// <returns></returns>
        // GET: api/People
        public List<person> Get()
        {
            return people;
        }

        /// <summary>
        /// API to demonstrate the attribute routing along with complex return type.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public person GetPerson(int id)
        {
            return people.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// API to demonstrate the attribute routing along with primitive return type.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("api/People/GetId")]
        [HttpGet]
        public int GetName(string name)
        {
            return people.Where(x => x.FirstName == name).FirstOrDefault().Id;
        }

        /// <summary>
        /// API to demonstrate the attribute routing along with HttpResponseMessage return type.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/People/GetResponse")]
        [HttpGet]
        public HttpResponseMessage GetRespns(int id)
        {
            person prsn = people.Where(x => x.Id == id).FirstOrDefault();
            HttpResponseMessage response;

            if (prsn == null)
            {
                 response = Request.CreateResponse(HttpStatusCode.NotFound, id);
                 response.ReasonPhrase = "Data not processed";
                response.Headers.CacheControl = new CacheControlHeaderValue()
                {
                    MaxAge = TimeSpan.FromMinutes(20)
                };
            }
            else
            {
                 response = Request.CreateResponse(HttpStatusCode.OK, prsn);
                 response.ReasonPhrase = "Data is processed";
            }

            return response;
        }

        /// <summary>
        /// API to demonstrate the attribute routing along with IHTTPActionResult return type.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/People/GetResponse_1")]
        [HttpGet]
        public IHttpActionResult GetIntRespns(int id)
        {
            person prsn = people.Where(x => x.Id == id).FirstOrDefault();

            if (prsn == null)
            {
                return NotFound();
            }

            return Ok(prsn);
        }

        /// <summary>
        /// API for POST method.
        /// </summary>
        /// <param name="val"></param>
        // POST: api/People
        public void Post(person val)
        {
            people.Add(val);
        }

        /// <summary>
        /// API for delete.
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/People/5
        public void Delete(int id)
        {

        }
    }
}
