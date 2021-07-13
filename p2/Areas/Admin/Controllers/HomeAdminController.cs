using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2.Models.Function;
using p2.Models.Entities;
using p2.Areas.Admin.Models.Function;
namespace p2.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            F_Candidate f_candi = new F_Candidate();
            F_User f_User = new F_User();
            var inforStudents = f_User.getUsers();
            ViewBag.Users = inforStudents;
            ViewBag.Candidates = f_candi.getInfor();
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult StudentList()
        {
            F_Candidate f_candi = new F_Candidate();
            F_User f_User = new F_User();
            var inforStudents = f_User.getUsers();
            ViewBag.Users = inforStudents;
            ViewBag.Candidates = f_candi.getInfor();
            return View();
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Index","Home",new { area = "" });
        }

        public ActionResult _PanelView()
        {
            return PartialView("_Panel");
        }
    }
}