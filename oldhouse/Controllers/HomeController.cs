
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using oldhouse.Models;
//using System.Drawing.Imaging;
//using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;


namespace oldhome.Controllers
{
    public class HomeController : Controller
    {
        OldHouseEntities1 DB = new OldHouseEntities1();

        String loginUser;
        String loginPassword;
        // GET: Home


        public ActionResult MainPage()
        {
            return View("");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(MyLogin login)
        {
            var r = DB.Registers.Where(a => a.UserName == login.UserName && a.Password == login.Password).FirstOrDefault();
            if (r != null)
            {
                loginUser = r.UserName;
                loginPassword = r.Password;
                TempData["id"] = r.id;
                return View("OldHome");
            }

            return View();

        }
        public ActionResult OldHome()
        {
            return View();

        }
        public ActionResult RequestAutofill()
        {

            return View();
        }
      //  [HttpPost]
      //public ActionResult RequestAutofill(Requested obj)
      //  {
      //      Requested a = new Requested()
      //      {
      //          Accept = obj.Accept,
      //          Request = obj.Request,
      //          Reject = obj.Reject,
      //      }
      //      return View("RequestAutofill",obj);
      //  }
        public ActionResult Services()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Services(Image image)
        {
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            image.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            image.ImageFile.SaveAs(fileName);
            DB.Images.Add(image);
            int b = DB.SaveChanges();
            return View();

        }
        public ActionResult ViewServices()
        {
            return View(DB.Images.ToList());
        }



        [HttpPost]
        public ActionResult AddDetailsAutoFill(MyRegister login)
        {
            var r = DB.Registers.Where(a => a.UserName == login.UserName && a.Password == login.Password).FirstOrDefault();

            MyRegister register = new MyRegister()
            {
                id=r.id,
                FullName = r.FullName,
                ContactNo = r.ContactNo,
                Address = r.Address,
                City = r.City,
                TotalSeats = r.TotalSeats,
                VacantSeats = r.VacantSeats,
                Gender = r.Gender
            };


            return View("AddDetails", register);
        }
        [HttpGet]
        public ActionResult ShowDetails()
        {
            MyRegister obj = new MyRegister();
            obj.City = TempData["value"].ToString();
            obj.UserName = TempData["value"].ToString();
            obj.Gender = TempData["value"].ToString();
            var r = DB.Registers.Where(a => a.UserName == obj.UserName ).FirstOrDefault();

            MyRegister register = new MyRegister()
            {
                FullName = r.FullName,
                ContactNo = r.ContactNo,
                Address = r.Address,
                City = r.City,
                TotalSeats = r.TotalSeats,
                VacantSeats = r.VacantSeats,
            };
            //ViewBag.value = register;

            return View("ShowDetails", register);
        }
        [HttpGet]
        public ActionResult Details()
        {
            return View("UserOldHome");
        }
        [HttpPost]
        public ActionResult Details(string UserName,string Gender,string City)
        {
            var r = DB.Registers.Where(a => a.UserName == UserName).FirstOrDefault();
            if (UserName!="")
                r = DB.Registers.Where(a => a.UserName == UserName).FirstOrDefault();
            else if(Gender!="")
                r = DB.Registers.Where(a => a.Gender == Gender).FirstOrDefault();
            else if (City!="")
                r = DB.Registers.Where(a => a.City == City).FirstOrDefault();
            MyRegister register = new MyRegister()
            {
                FullName = r.FullName,
                ContactNo = r.ContactNo,
                Address = r.Address,
                City = r.City,
                UserName = r.UserName,
                id = r.id,
            };
            //ViewBag.value = register;

            TempData["value"] = register.UserName;
            TempData["id"] = register.id;
            return View("UserOldHome",register );
        }

        //public ActionResult UploadImage()

        //{

        //    return View();



     

        //[HttpPost]
        //public ActionResult UploadImage(MyImage myimage)
        //{
        //    foreach (var a in myimage.FileAttachment)
        //    {
        //        BinaryReader br = new BinaryReader(a.InputStream);

        //        //myimage.Image = Convert.ToBase64String(br.ReadBytes(a.ContentLength));
        //        myimage.Image1 = a.ContentType;

        //        Image imagetbl = new Image()
        //        {
        //            Name = myimage.Name,
        //            //ImageData = myimage.Image,
        //            Image1 = myimage.Image1
        //        };
        //        //ViewBag.Message = "Image upload Successfully";
        //        DB.Images.Add(imagetbl);

        //        int b = DB.SaveChanges();

        //    }
        //    //var item = (from d in DB.Images select d);
        //    return View();
        //}
     




        [HttpGet]
        public ActionResult AddDetails()
        {
            return View();
        }


       

        public ActionResult Package()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Package(MyPackage package)
        {
            Package r = new Package()
            {
                BookingType = package.BookingType,
                PackageName = package.PackageName,
                PackageDetails = package.PackageDetails,
                Duration = package.Duration,
                Price = package.Price,
                Installment = package.Installment,
                regid = int.Parse(TempData["id"].ToString()),
            };
            TempData["id"] = r.regid;
            DB.Packages.Add(r);
            DB.SaveChanges();
            return View();
        }

        public ActionResult ViewPackage()
        {
            if (TempData["id"] != null)
            {
                int value = int.Parse(TempData["id"].ToString());
                //var r = DB.Packages.Where(a => a.regid == value).FirstOrDefault();
                var r = DB.Packages.Where(a => a.regid == value).ToList();
                //Package register = new Package()
                //{
                //    BookingType = r.BookingType,
                //    PackageName = r.PackageName,
                //    PackageDetails = r.PackageDetails,
                //};
                return View(r);
            }
            else
                return View();
        }
        public ActionResult SearchPackage()
        {
            if (TempData["id"] != null)
            {
                int value = int.Parse(TempData["id"].ToString());
                TempData["data"] = value;

                //var r = DB.Packages.Where(a => a.regid == value).FirstOrDefault();
                var r = DB.Packages.Where(a => a.regid == value).ToList();
                //Package register = new Package()
                //{
                //    BookingType = r.BookingType,
                //    PackageName = r.PackageName,
                //    PackageDetails = r.PackageDetails,
                //};
                return View("SearchPackage",r.ToList<Package>());
            }
            else
                return View();
        }
        [HttpPost]
        public ActionResult SearchPackage(string type)
        {

            if (TempData["data"] != null)
            {
                int value = int.Parse(TempData["data"].ToString());
                TempData["data"] = value;
                var r = DB.Packages.Where(a => a.regid == value && a.BookingType == type).ToList();
                //var r = DB.Packages.Where(a => a.regid == value).FirstOrDefault();
                if (type!="")
                    r = DB.Packages.Where(a => a.regid == value && a.BookingType == type).ToList();
                else
                    r = DB.Packages.Where(a => a.regid == value).ToList();
                //Package register = new Package()
                //{
                //    BookingType = r.BookingType,
                //    PackageName = r.PackageName,
                //    PackageDetails = r.PackageDetails,
                //};
                return View(r);
            }
            else
                return View();
        }


        public ActionResult UserOldHome()
        {

            return View();
        }
       


        public ActionResult SetPolicy()
        {
            return View("");

        }


        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(MyRegister register)
        {
            Register r = new Register()
            {
                FullName = register.FullName,
                ContactNo = register.ContactNo,
                Email = register.Email,
                City = register.City,
                Address = register.Address,
                UserName = register.UserName,
                Password = register.Password,
                UserType = register.UserType,
                TotalSeats = register.TotalSeats,
                VacantSeats = register.VacantSeats,
                Gender = register.Gender
            };

            DB.Registers.Add(r);
            
            DB.SaveChanges();

            return View();



        }

        [HttpPost]
        public ActionResult ModifyOldHome(MyRegister registertbl)
        {

                var register = DB.Registers.Find(registertbl.id);
                if (register == null)
                {
                    return null;
                }
           
                DB.Entry(register).CurrentValues.SetValues(registertbl);
                DB.SaveChanges();
                return View();


            
            
        }
        public ActionResult Requested()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Requested(Requested request)
        {
            Requested r = new Requested()
            {
                Accept = request.Accept,
                Request = request.Request,
                Reject = request.Reject,

            };
            DB.Requesteds.Add(r);
            DB.SaveChanges();
        
            return View();

        }

    }
}
       
       
      
   
