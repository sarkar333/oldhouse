using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oldhouse.Models;
namespace oldhouse.Controllers
{
    public class ImageController : Controller
    {
        OldHouseEntities1 DB = new OldHouseEntities1();
        public ActionResult ImageAdd()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult ImageAdd(Myimage s)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //BinaryReader br = new BinaryReader(s.ImageFile.InputStream);
        //        //s.Image = Convert.ToBase64String(br.ReadBytes(s.ImageFile.ContentLength));
        //        //s.ImageType = s.ImageFile.ContentType;
        //        string fileName = Path.GetFileNameWithoutExtension(s.ImageFile.FileName);
        //        string extension = Path.GetExtension(s.ImageFile.FileName);
        //        HttpPostedFileBase postedFile = s.ImageFile;
        //        int length = postedFile.ContentLength;
        //        fileName = fileName + extension;
        //        s.Image = "~/images/" + fileName;
        //        fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
        //        s.ImageFile.SaveAs(fileName);
        //        DB.Imagetbl.Add(s);
        //        DB.SaveChanges();
        //    }
        //    return View();
        //}
        //public ActionResult View()
        //{
        //    Imagetbl OldHouseEntities = new Imagetbl();
        //    OldHouseEntities = DB.Imagetbl.Where(x => x.Imageid == id).FirstorDefault();
        //    return View();
        //}

    }
}
