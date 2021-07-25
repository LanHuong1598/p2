using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2.Models.Function;

namespace p2.Areas.Admin.Controllers
{
    public class AccountStudentController : BaseAdminController
    {
        // GET: Admin/AccountStudent
        public ActionResult Index()
        {
            ViewBag.layout = "account";
            F_User f_user = new F_User();
            ViewBag.ListUser = f_user.getListUser();
            return View();
        }

        public ActionResult DetailAccountStudent(Guid code)
        {
            ViewBag.layout = "account";
            F_User f_user = new F_User();
            ViewBag.Account = f_user.getUserbyCode(code);
            return View();
        }

        [HttpGet]
        public JsonResult ResetPassword(Guid code, string password_new)
        {
            F_User f_User = new F_User();
            var result = f_User.ResetPassword(code,password_new);
            return Json(result, JsonRequestBehavior.AllowGet);
          
        }
    }
}