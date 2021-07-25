using p2.Authorization;
using p2.Models.Entities;
using p2.Models.Function;
using p2.Models.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2.Areas.Admin.Models.Function;
using p2.Areas.Admin.Models.Handler;
namespace p2.Areas.Admin.Controllers
{
    public class StudentController : BaseAdminController
    {
        // GET: Admin/Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AccountLoginStudent(Guid? studentcode)
        {
            
            return View();
        }
        public ActionResult AddStudent()
        {
            F_Area f_Area = new F_Area();
            ViewBag.Province = f_Area.getProvincials();
            F_status_mark f_status_mark = new F_status_mark();
        
            F_region_mark f_region_mark = new F_region_mark();
            F_enrollment f_Enrollment = new F_enrollment();
            F_record f_record = new F_record();
            ViewBag.Districts = f_Area.getDistricts();
            ViewBag.Towns = f_Area.getTowns();
            ViewBag.Enrollment = f_Enrollment.Getenrollment();
            ViewBag.StatusMark = f_status_mark.getStatus_marks();
            ViewBag.RegionMark = f_region_mark.getRegionMarks();
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Information_student infor_student)
        {


            F_Area f_Area = new F_Area();
            ViewBag.Province = f_Area.getProvincials();
            F_status_mark f_status_mark = new F_status_mark();

            F_region_mark f_region_mark = new F_region_mark();
            F_enrollment f_Enrollment = new F_enrollment();
            F_record f_record = new F_record();
            ViewBag.Districts = f_Area.getDistricts();
            ViewBag.Towns = f_Area.getTowns();
            ViewBag.Enrollment = f_Enrollment.Getenrollment();
            ViewBag.StatusMark = f_status_mark.getStatus_marks();
            ViewBag.RegionMark = f_region_mark.getRegionMarks();
            F_Student f_student = new F_Student();
            string ipadd = new F_IpAdress().GetIp();
            Guid check = f_student.AddNewStudent(infor_student, "Admin",ipadd, DateTime.Now, "Create");
            if(check != null)
            {

                ViewBag.Mess = "Đã thêm thành công thí sinh";
                return Redirect("/Admin/Student/DetailStudent?code=" + check);
            }
            ViewBag.Mess = "Thêm thí sinh không thành công, thử lại!";
            return View();
        }
        public ActionResult DetailUpdateStudent(Guid code)
        {

            F_Candidate f_candi = new F_Candidate();

            
            F_status_mark f_status_mark = new F_status_mark();
            F_Area f_Area = new F_Area();
            F_region_mark f_region_mark = new F_region_mark();
            F_enrollment f_Enrollment = new F_enrollment();
            F_record f_record = new F_record();
            Information_History_Update_Student student = new Information_History_Update_Student();
            student = f_candi.getInforUpdate(code);

            string name = student.name;
            ViewBag.Name = name;
            
            ViewBag.Province = f_Area.getProvincials();
            ViewBag.User = student;
            if (student.towncode != null)
            {
                string districtcode = f_Area.getDistrictCodeByTown(student.towncode);
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

        public ActionResult ListStudentDuplicateIdentity(string identity)
        {
            ViewBag.layout = "duplicate";
            F_Candidate f_candi = new F_Candidate();
            ViewBag.ListDuplicate = f_candi.getListStudentDuplicateIdentity(identity);
            ViewBag.Identity = identity;
            return View();
        }
        public ActionResult DetailStudent(Guid code)
        {
            
            F_User f_User = new F_User();

            var user = f_User.getByID(code);
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
            if (student.active == 1)
            {
                ViewBag.Mess = "Đã nộp hồ sơ thành công";
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
    }
}