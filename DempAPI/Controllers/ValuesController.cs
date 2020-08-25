using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DempAPI.Controllers
{

    /// <summary>
    /// Bellow are the value controller API's
    /// </summary>
    public class ValuesController : ApiController
    {
        /// <summary>
        /// This API returns an array of values.
        /// </summary>
        /// <returns></returns>
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// This API returns a a particular user value.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// POST API
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// PUT API
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Delete API
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
