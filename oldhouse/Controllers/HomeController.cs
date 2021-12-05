
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using oldhouse.Models;
//using System.Drawing.Imaging;
//using System.Net;

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
            Register r = DB.Registers.Where(a => a.UserName == login.UserName && a.Password == login.Password).FirstOrDefault();
            if (r != null)
            {
                loginUser = r.UserName;
                loginPassword = r.Password;

                return View("OldHome");
            }
            return View();

        }
        public ActionResult OldHome()
        {
            return View("");

        }


        [HttpPost]
        public ActionResult AddDetailsAutoFill(MyLogin login)
        {
            var r = DB.Registers.Where(a => a.UserName == login.UserName && a.Password == login.Password).FirstOrDefault();

            MyRegister register = new MyRegister()
            {
                FullName = r.FullName,
                ContactNo = r.ContactNo,
                Address = r.Address,
                City = r.City,
            };
            return View("AddDetails", register);
        }
        public ActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(Myimage myimage)
        {
            foreach (var a in myimage.FileAttachment)
            {
                BinaryReader br = new BinaryReader(a.InputStream);

                myimage.Image = Convert.ToBase64String(br.ReadBytes(a.ContentLength));
                myimage.ImageType = a.ContentType;

                Image imagetbl = new Image()
                {
               ImageName = myimage.ImageName,
                    ImageData = myimage.Image,
                    ImageType = myimage.ImageType
                };
                //ViewBag.Message = "Image upload Successfully";
                DB.Images.Add(imagetbl);
                
             int b=   DB.SaveChanges();
                //ViewBag.Message = "Image upload Successfully";
                if (b > 0)
                {
                    ViewBag.Message="<Script>alert('Picture Upload scessfully')</script>";
                }
                else
                {
                    ViewBag.Message = "<Script>alert('Not Uploaded')</script>";
                }
            }
            return View();
        }
        
        public ActionResult ViewServices()
        {
            //List<Image> S = new List<Image>();
            //S = DB.Images.ToList();
            //return View(S);

            //myimage = DB.Images.Where(x => x.id == id).FirstOrDefault();
            //var r = DB.Images.Where(a => a.id == id).FirstOrDefault();
            //Image myimage = new Image()
           // {
             //   ImageName = r.ImageName,
               // ImageData = r.ImageData,
                //ImageType = r.ImageType,

            //};
           


            return View();
        }



        [HttpPost]
        public ActionResult AddDetails()
        {
            return View();
        }
        
      
       /* [HttpPost]*/
       /* public ActionResult Services(Myimage s)
        {
            if (ModelState.IsValid)
            {
               
                
                    //BinaryReader br = new BinaryReader(s.ImageFile.InputStream);
                    //s.Image = Convert.ToBase64String(br.ReadBytes(s.ImageFile.ContentLength));
                    //s.ImageType = s.ImageFile.ContentType;
                    //Imagetbl R = new Imagetbl()
                    //{
                    //    Image = s.Image,
                    //    ImageType = s.ImageType
                    //};
                    //DB.Imagetbls.Add(R);

                    string fileName = Path.GetFileNameWithoutExtension(s.ImageFile.FileName);
                    string extension = Path.GetExtension(s.ImageFile.FileName);
                    HttpPostedFileBase postedFile = s.ImageFile;
                    int length = postedFile.ContentLength;

                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg")
                    {
                        if (length <= 1000000)
                        {
                            fileName = fileName + extension;
                            s.Image = "~/images/" + fileName;
                            fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                            s.ImageFile.SaveAs(fileName);
                            Imagetbl R = new Imagetbl()
                            {
                                Image = fileName,
                                ImageType = s.ImageType
                            };
                            DB.Imagetbls.Add(R);

                            DB.SaveChanges();
        
                   return View();
        }*/


       
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
                UserType = register.UserType
            };
            ViewBag.message("Successfull");
            DB.Registers.Add(r);
            DB.SaveChanges();

            return View();
            


        }
    }
}
     
       
       
      
   
