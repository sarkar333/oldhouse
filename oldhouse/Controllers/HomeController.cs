using oldhouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace oldhome.Controllers
{
    public class HomeController : Controller
    {
        OldHouseEntities DB = new OldHouseEntities();
        // GET: Home
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
                return View("OldHome");
            }
            return View();

        }
        public ActionResult OldHome()
        {
              return View("AddDetails");

        }

        public ActionResult AddDetails()
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
            DB.Registers.Add(r);
            DB.SaveChanges();

            return View();
            


        }
    }
}
     
       
       
      
   
