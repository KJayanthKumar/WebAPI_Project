using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DempAPI.Models
{
    public class person1
    {
        /// <summary>
        /// ID from SQL
        /// </summary>
        public int Id { get; set; } = 0;
        /// <summary>
        /// The users's first name.
        /// </summary>
        public string FirstName { get; set; } = "";
        /// <summary>
        /// The users's last name.
        /// </summary>
        public string LastName { get; set; } = "";

        /// <summary>
        /// The users's Age.
        /// </summary>
        public int Age { get; set; } = 0;
    }
}