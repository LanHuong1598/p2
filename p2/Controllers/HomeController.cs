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
        public ActionResult Index(string username, string password)
        {
            bool statusLogin = new F_User().Login(username, password);
            bool statusLoginAdmin = new F_User().LoginAdmin(username, password);
            if (statusLogin == true)
            {
                F_User f_user = new F_User();
                var user = f_user.getUserLogin(username,password);
                Session.Add(CommonConstants.USER_SESSION, user);
                return RedirectToAction("DashBoard", "User");
            }
            else if(statusLoginAdmin==true)
            {
                F_User f_user = new F_User();
                var useradmin = f_user.getUserLoginAdmin(username, password);
                Session.Add(CommonConstants.ADMIN_SESSION, useradmin);
                return RedirectToAction("DashBoard", "HomeAdmin", new { area = "Admin" });
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
        public ActionResult Register(user account, string password_confirm)
        {

            F_User f_user = new F_User();
            string ipaddress = "";
            ipaddress = Request.UserHostAddress;
            string result = f_user.Register(account, password_confirm,ipaddress);
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
        public ActionResult up(user user, SchoolRecord record)
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