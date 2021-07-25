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
            F_User f_User = new F_User();
            var accountLogin = CookiesManage.getUser();
            var user = f_User.getPrestudentByUser(accountLogin);
            F_status_mark f_status_mark = new F_status_mark();
            F_Area f_Area = new F_Area();
            F_region_mark f_region_mark = new F_region_mark();
            F_enrollment f_Enrollment = new F_enrollment();
            F_record f_record = new F_record();
            string name = user.name;
            ViewBag.Name = name;
            Information_student student = new Information_student();
            student = f_User.getInformationStudent(user.code);
            ViewBag.Province = f_Area.getProvincials();
            ViewBag.User = student;
            if (user.towncode != null)
            {
                string districtcode = f_Area.getDistrictCodeByTown(user.towncode);
                ViewBag.DistrictCode = districtcode;
                string provincialCode = f_Area.getProvincialCodeByDistrict(districtcode);
                ViewBag.ProvinceCode = provincialCode;
                List<district> Districts = f_Area.getDistrictsByProvincial(provincialCode);
                List<town> Towns = f_Area.getTownsByDistrict(districtcode);
                ViewBag.Districts = Districts;
                ViewBag.Towns = Towns;
            }
            ViewBag.Enrollment = f_Enrollment.Getenrollment();
            ViewBag.StatusMark = f_status_mark.getStatus_marks();
            ViewBag.RegionMark = f_region_mark.getRegionMarks();
            ViewBag.Record10_1 = f_record.getRecodebyCode(student.record_10_1_code);
            ViewBag.Record10_2 = f_record.getRecodebyCode(student.record_10_2_code);
            ViewBag.Record11_1 = f_record.getRecodebyCode(student.record_11_1_code);
            ViewBag.Record11_2 = f_record.getRecodebyCode(student.record_11_2_code);
            ViewBag.Record12_1 = f_record.getRecodebyCode(student.record_12_1_code);
            ViewBag.Record12_2 = f_record.getRecodebyCode(student.record_12_2_code);

            return View();
        }
        [HttpPost]
        public ActionResult Index(Information_student infor_user)
        {
            var accountLogin = CookiesManage.getUser();
            F_User f_User = new F_User();
            F_region_mark f_region_mark = new F_region_mark();
            F_enrollment f_Enrollment = new F_enrollment();
            F_status_mark f_status_mark = new F_status_mark();
            F_record f_record = new F_record();
            F_IpAdress f_ip = new F_IpAdress();
            string ipaddress = f_ip.GetIp();
            DateTime now = DateTime.Now;
            f_User.update_Information(infor_user,accountLogin.username,ipaddress,now,"Edit");
            F_Area f_Area = new F_Area();
            string name = infor_user.name;
            ViewBag.Name = name;
            ViewBag.Towns = f_Area.getTowns();
            ViewBag.Province = f_Area.getProvincials();
            ViewBag.User = f_User.getInformationStudent(infor_user.code);
            Information_student student = new Information_student();
            student = f_User.getInformationStudent(infor_user.code);
            if (infor_user.towncode != null)
            {
                string districtcode = f_Area.getDistrictCodeByTown(infor_user.towncode);
                ViewBag.DistrictCode = districtcode;
                string provincialCode = f_Area.getProvincialCodeByDistrict(districtcode);
                ViewBag.ProvinceCode = provincialCode;
                List<district> Districts = f_Area.getDistrictsByProvincial(provincialCode);
                List<town> Towns = f_Area.getTownsByDistrict(districtcode);
                ViewBag.Districts = Districts;
                ViewBag.Towns = Towns;
                ViewBag.TownCode = infor_user.towncode;
            }

            ViewBag.Enrollment = f_Enrollment.Getenrollment();
            ViewBag.StatusMark = f_status_mark.getStatus_marks();
            ViewBag.RegionMark = f_region_mark.getRegionMarks();
            ViewBag.Record10_1 = f_record.getRecodebyCode(student.record_10_1_code);
            ViewBag.Record10_2 = f_record.getRecodebyCode(student.record_10_2_code);
            ViewBag.Record11_1 = f_record.getRecodebyCode(student.record_11_1_code);
            ViewBag.Record11_2 = f_record.getRecodebyCode(student.record_11_2_code);
            ViewBag.Record12_1 = f_record.getRecodebyCode(student.record_12_1_code);
            ViewBag.Record12_2 = f_record.getRecodebyCode(student.record_12_2_code);
            return View();
        }

        public JsonResult getDistrictsByProvincial(string provincialcode)
        {
            F_Area f_Area = new F_Area();
            var result = f_Area.getDistrictsByProvincial(provincialcode);
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public JsonResult getTownsByDistrict(string districtcode)
        {
            F_Area f_Area = new F_Area();
            var result = f_Area.getTownsByDistrict(districtcode);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DashBoard()
        {
            F_User f_user = new F_User();
            user account = new user();
            account = CookiesManage.getUser();
            int check_identitycatd = f_user.checkIdentityCard(account);
            ViewBag.checkCMND = check_identitycatd;
            ViewBag.Name = account.name;
            return View();
        }

        public ActionResult ViewUser()
        {
            F_User f_User = new F_User();
            var accountLogin = CookiesManage.getUser();
            var user = f_User.getPrestudentByUser(accountLogin);
            F_status_mark f_status_mark = new F_status_mark();
            F_Area f_Area = new F_Area();
            F_region_mark f_region_mark = new F_region_mark();
            F_enrollment f_Enrollment = new F_enrollment();
            F_record f_record = new F_record();
            string name = user.name;
            ViewBag.Name = name;
            Information_student student = new Information_student();
            student = f_User.getInformationStudent(user.code);
            ViewBag.Province = f_Area.getProvincials();
            ViewBag.User = student;
            if (user.towncode != null)
            {
                string districtcode = f_Area.getDistrictCodeByTown(user.towncode);
                ViewBag.DistrictCode = districtcode;
                string provincialCode = f_Area.getProvincialCodeByDistrict(districtcode);
                ViewBag.ProvinceCode = provincialCode;
                List<district> Districts = f_Area.getDistrictsByProvincial(provincialCode);
                List<town> Towns = f_Area.getTownsByDistrict(districtcode);
                ViewBag.Districts = Districts;
                ViewBag.Towns = Towns;
                ViewBag.townname = f_Area.getTownbycode(student.towncode).name;
                ViewBag.districtname = f_Area.getDistrictbycode(student.districtcode).name;
                ViewBag.provincename = f_Area.getProvincebycode(student.provincecode).name;
                ViewBag.TownCode = student.towncode;


            }
            if (user.enrollment_code != null)
            {
                ViewBag.enrollmentname = f_Enrollment.getEnrollmentbyCode(student.enrollment_code).name;
            }
            if (student.enrollment_code != null)
            {
                ViewBag.enrollmentname = f_Enrollment.getEnrollmentbyCode(student.enrollment_code).name;
            }
            if (student.statusmark_code != null)
            {
                ViewBag.statusmarkname = f_status_mark.getStatusByCode(student.statusmark_code).name;
            }
            if (student.regionmark_code != null)
            {
                ViewBag.regionmarkname = f_region_mark.getRegionByCode(student.regionmark_code).name;
            }


            ViewBag.Record10_1 = f_record.getRecodebyCode(student.record_10_1_code);
            ViewBag.Record10_2 = f_record.getRecodebyCode(student.record_10_2_code);
            ViewBag.Record11_1 = f_record.getRecodebyCode(student.record_11_1_code);
            ViewBag.Record11_2 = f_record.getRecodebyCode(student.record_11_2_code);
            ViewBag.Record12_1 = f_record.getRecodebyCode(student.record_12_1_code);
            ViewBag.Record12_2 = f_record.getRecodebyCode(student.record_12_2_code);
            return View();
        }

        public ActionResult ChangePassword()
        {
            F_User f_User = new F_User();
            var accountLogin = CookiesManage.getUser();
            ViewBag.Name = accountLogin.name;
            return View();
        }

       [HttpPost]
        public ActionResult ChangePassWord(string password_old, string password_new, string confirmpassword_new)
        {

            
            string result = "";
            F_User f_user = new F_User();
            var user_ = CookiesManage.getUser();
            result = f_user.ChangePassword(user_.code, password_old, password_new, confirmpassword_new);
            if (result != "Thành công")
            {
                ModelState.AddModelError("", result);
            }
            else
            {
                ViewBag.mess = "Thành công";
                ModelState.AddModelError("", "Thay đổi mật khẩu thành công");
            }
            return View();
        }

    }
}