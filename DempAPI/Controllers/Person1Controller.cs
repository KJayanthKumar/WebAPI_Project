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
    /// Version_1 API's.
    /// </summary>
    public class Person1Controller : ApiController
    {
        List<person1> person = new List<person1>();
        public Person1Controller()
        {
            person.Add(new person1 { FirstName = "Andreson", LastName = "Corey", Id = 1, Age = 32 });
            person.Add(new person1 { FirstName = "Jayanth", LastName = "Kumar", Id = 2, Age = 27 });
            person.Add(new person1 { FirstName = "Trijal", LastName = "K", Id = 3, Age = 37 });
            person.Add(new person1 { FirstName = "Virat", LastName = "Kohli", Id = 4, Age = 31 });
            person.Add(new person1 { FirstName = "AB", LastName = "D", Id = 5, Age = 35  });
            person.Add(new person1 { FirstName = "yuzi", LastName = "Chahal", Id = 6, Age= 29 });
        }

        /// <summary>
        /// Version_1 API to return the list of person.
        /// </summary>
        /// <returns></returns>
        public List<person1> Get()
        {
            return person;
        }

        /// <summary>
        /// Version_1 API to return single person based on id.
        /// </summary>
        /// <returns></returns>
        public person1 Get(int id)
        {
            return person.Where(x => x.Id == id).FirstOrDefault();
        }

    }
}
