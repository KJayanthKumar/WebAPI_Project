using DempAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DempAPI.Controllers
{
    /// <summary>
    /// Version_2 API's.
    /// </summary>
    public class Person2Controller : ApiController
    {
        List<person2> person = new List<person2>();
        public Person2Controller()
        {
            person.Add(new person2 { FirstName = "Andreson", LastName = "Corey", Id = 1, Age = 32, Team = "NZ" });
            person.Add(new person2 { FirstName = "Jayanth", LastName = "Kumar", Id = 2, Age = 27, Team = "IND" });
            person.Add(new person2 { FirstName = "Trijal", LastName = "K", Id = 3, Age = 37, Team = "IND" });
            person.Add(new person2 { FirstName = "Virat", LastName = "Kohli", Id = 4, Age = 31, Team = "RCB" });
            person.Add(new person2 { FirstName = "AB", LastName = "D", Id = 5, Age = 35, Team = "RCB" });
            person.Add(new person2 { FirstName = "yuzi", LastName = "Chahal", Id = 6, Age = 29, Team = "RCB" });
        }

        /// <summary>
        /// Version_2 API to return the list of person.
        /// </summary>
        /// <returns></returns>
        public List<person2> Get()
        {
            return person;
        }

        /// <summary>
        /// Version_2 API to return single person based on id.
        /// </summary>
        /// <returns></returns>
        public person2 Get(int id)
        {
            return person.Where(x => x.Id == id).FirstOrDefault();
        }

    }
}
