using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace oldhouse.Models
{
    public class MyRegister
    {
        public long id { get; set; }
        public string FullName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public string TotalSeats { get;  set; }

        public string VacantSeats { get; set; }
        public string Gender { get; set; }
    }
}