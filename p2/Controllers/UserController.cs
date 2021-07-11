using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2.Models.Entities;
using p2.Models.Handler;
using p2.Authorization;
using p2.Models.Function;
namespace p2.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            var user = CookiesManage.getUser();
            F_Area f_Area = new F_Area();
            string name = user.name;
            ViewBag.Name = name;
            ViewBag.Area = f_Area.getAreas();
            ViewBag.User = user;
            return View();
        }
        [HttpPost]
        public ActionResult Update_Information(imformation_user user, SchoolRecord record)
        {
            F_User f_User = new F_User();
            f_User.update_Information(user, record);
            F_Area f_Area = new F_Area();
            string name = user.name;
            ViewBag.Name = name;
            ViewBag.Area = f_Area.getAreas();
            user = f_User.getByID(user.id);
            ViewBag.User = user;
            return View("Index");
        }

        public JsonResult getDistrictsByProvincial(string provincialID)
        {
            F_Area f_Area = new F_Area();
            var result = f_Area.getDistrictsByProvincial(provincialID);
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public JsonResult getCommunesByDistrict(string districtID)
        {
            F_Area f_Area = new F_Area();
            var result = f_Area.getCommunesByDistrict(districtID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}