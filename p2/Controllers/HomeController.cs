using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2.Models.Function;
using p2.Models.Entities;
using p2.Authorization;
using p2.Models.Handler;
namespace p2.Controllers
{
    public class HomeController : Controller
    {
        DBContext dbcontext;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string id, string password)
        {
            bool statusLogin = new F_User().Login(id, password);
            if (statusLogin == true)
            {
                F_User f_user = new F_User();
                var user = f_user.getByID(id);
                Session.Add(CommonConstants.USER_SESSION, user);
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
               
                return View("Index");
            }
            
        }

        public ActionResult Logout()
        {
            Session.Add(CommonConstants.USER_SESSION, null);
            return View("Index");
        }
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(account_user account, string password_confirm)
        {

            F_User f_user = new F_User();
            string result = f_user.Register(account, password_confirm);
            if (result != "Thành công")
            {
                var err = result.Split('/');
                for (int i = 0;i<err.Length;i++)
                {
                    if (err[i] != "")
                    {
                        ModelState.AddModelError("", err[i]);
                    }
                    
                }
                return View("Register");
            }
            return View("Index");
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
        [HttpPost]
        public ActionResult up(account_user user, SchoolRecord record)
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