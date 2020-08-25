using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace DempAPI.Models
{
    /// <summary>
    /// Represents a one specific person.
    /// </summary>
    public class person
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
        /// The users 's last name.
        /// </summary>
        public string LastName { get; set; } = "";

    }

    public static class logs
    {
        static private StreamWriter _filewrite = null;
        static string LOG_FILE_PATH = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Logs/log.txt");

        static public StreamWriter filewrite
        {
            get
            {
                if (_filewrite == null)
                {
                    _filewrite = new StreamWriter(LOG_FILE_PATH, true, Encoding.UTF8);
                }
                return _filewrite;
            }
            set
            {
                _filewrite = value;
            }
        }
    }
}