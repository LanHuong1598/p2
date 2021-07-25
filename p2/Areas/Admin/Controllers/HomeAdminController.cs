using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2.Areas.Admin.Models.Function;
using p2.Authorization;

namespace p2.Areas.Admin.Controllers
{
    public class HomeAdminController : BaseAdminController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {

            ViewBag.layout = "dashboard";
            F_Candidate f_candi = new F_Candidate();
            ViewBag.List_Student_Commit = f_candi.getInfor();
            ViewBag.Statistic = f_candi.stats();

            var accountLoginAdmin = CookiesManage.getAdmin();
            ViewBag.nameadmin = accountLoginAdmin.name;
            return View();
        }
        public JsonResult getNameAdmin()
        {
            var accountLoginAdmin = CookiesManage.getAdmin();
            ViewBag.nameadmin = accountLoginAdmin.name;
            return Json(accountLoginAdmin.name, JsonRequestBehavior.AllowGet);
        }
        public ActionResult History_Update_Student()
        {
            ViewBag.layout = "history";
            F_Candidate f_candi = new F_Candidate();
            ViewBag.List_Student_Commit = f_candi.getInfor();
            return View();
        }
        public ActionResult LogoutAdmin()
        {
            Session.Add(CommonConstants.ADMIN_SESSION, null);
            return Redirect("/Home/Index");
           
        }
        public ActionResult List_detail_update(Guid code)
        {
            ViewBag.layout = "history";
            F_Candidate f_candi = new F_Candidate();
            ViewBag.List_Detail_Update = f_candi.getList_detail_update(code);
            return View();
        }
        public ActionResult Duplicate_IdentityCard()
        {
            ViewBag.layout = "duplicate";
            F_Candidate f_candi = new F_Candidate();
            var result = f_candi.getDuplicateIdentity();
            ViewBag.Duplicates = result;
            return View();
        }
    }
}