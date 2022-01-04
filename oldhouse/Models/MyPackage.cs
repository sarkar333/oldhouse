using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace oldhouse.Models
{
    public class MyPackage
    {
        public long id { get; set; }
        public String BookingType { get; set; }
        public String PackageName { get; set; }
        public String PackageDetails { get; set; }
        public String Duration { get; set; }
        public String Price { get; set; }
        public String Installment { get; set; }
        
        
    }
}