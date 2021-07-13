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
            F_Priority_object f_Priority_ = new F_Priority_object();
            F_Area f_Area = new F_Area();
            F_area_object f_area_object = new F_area_object();
            F_Admisson_group f_admisson_Group = new F_Admisson_group();
            string name = user.name;
            ViewBag.Name = name;
            ViewBag.Area = f_Area.getAreas();
            ViewBag.Provincials = f_Area.getProvincials();
            ViewBag.User = user;
            if (user.area != null)
            {             
                string districtID = f_Area.getDistrictIDByCommune(user.area);
                ViewBag.DistrictID = districtID;
                string provincialID = f_Area.getProvincialIDByDistrict(districtID);
                ViewBag.ProvincialID = provincialID;
                List<area> Districts = f_Area.getDistrictsByProvincial(provincialID);
                List<area> Communes = f_Area.getCommunesByDistrict(districtID);
                ViewBag.Districts = Districts;
                ViewBag.Communes = Communes;
             }
            ViewBag.Priority_Object = f_Priority_.getPriority_Objects();
            ViewBag.Area_Object = f_area_object.getAreaObjects();
            ViewBag.Admission_group = f_admisson_Group.GetAdmission_Groups();
            return View();
        }
        [HttpPost]
        public ActionResult Index(imformation_user user, SchoolRecord record)
        {
            F_User f_User = new F_User();
            F_area_object f_area_object = new F_area_object();
            F_Admisson_group f_admisson_Group = new F_Admisson_group();
            F_Priority_object f_Priority_ = new F_Priority_object();
            f_User.update_Information(user, record);
            F_Area f_Area = new F_Area();
            string name = user.name;
            ViewBag.Name = name;
            ViewBag.Area = f_Area.getAreas();
            ViewBag.Provincials = f_Area.getProvincials();
            ViewBag.User = f_User.getByID(user.id);
            if (user.area != null)
            {
                string districtID = f_Area.getDistrictIDByCommune(user.area);
                ViewBag.DistrictID = districtID;
                string provincialID = f_Area.getProvincialIDByDistrict(districtID);
                ViewBag.ProvincialID = provincialID;
                List<area> Districts = f_Area.getDistrictsByProvincial(provincialID);
                List<area> Communes = f_Area.getCommunesByDistrict(districtID);
                ViewBag.Districts = Districts;
                ViewBag.Communes = Communes;
            }

            ViewBag.Admission_group = f_admisson_Group.GetAdmission_Groups();
            ViewBag.Priority_Object = f_Priority_.getPriority_Objects();
            ViewBag.Area_Object = f_area_object.getAreaObjects();
            return View();
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