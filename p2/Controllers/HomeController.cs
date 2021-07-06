using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2.Models.Function;
using p2.Models.Entities;
namespace p2.Controllers
{
    public class HomeController : Controller
    {
        DBContext dbcontext;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(account_user account,string password_confirm)
        {

            F_User f_user = new F_User();
            string result = f_user.Register(account,password_confirm);
            return View();
        }

        public ActionResult ForgetPassword()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Information()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult test()
        {
            return View();
        }

        public ActionResult Upfile(HttpPostedFileBase file)
        {
            file.SaveAs(@"C:\Users\KhanhToan\Desktop\45.jpg");
            return View();
        }
    }
}