using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
namespace oldhouse.Models
{
    public class Myimage
    {
        public long id { get; set; }
        public String ImageName { get; set; }
        public  String ImageType { get; set; }
       
        public string Image { get; set; }

        public HttpPostedFileBase[] FileAttachment { get; set; }

    }
}