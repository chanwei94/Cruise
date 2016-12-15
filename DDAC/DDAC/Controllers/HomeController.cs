using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDAC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Models.Register register)
        {
            if (ModelState.IsValid)
            {
                using (MyDatabaseEntities db = new MyDatabaseEntities())
                {
                    UserData userdata = new UserData();
                    userdata.Username = register.Username;
                    userdata.Password = register.Password;
                    userdata.FullName = register.FullName;
                    userdata.Email = register.Email;
                    db.UserDatas.Add(userdata);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Successfully Registred";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserData userdata)
        {
            if (ModelState.IsValid)
            {
                using (MyDatabaseEntities db = new MyDatabaseEntities())
                {
                    var user = db.UserDatas.Where(a => a.Username.Equals(userdata.Username) && a.Password.Equals(userdata.Password)).FirstOrDefault();
                    if (user != null)
                    {
                        Session["LogedUserID"] = user.UserID.ToString();
                        return RedirectToAction("HomePage", "Activity");
                    }
                    else
                    {
                        Response.Write("<script> alert('Invalid username or password')</script>");           
                    }
                }
            }
            return View();
        }
    }
}