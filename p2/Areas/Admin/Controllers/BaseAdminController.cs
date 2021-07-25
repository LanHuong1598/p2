using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2.Authorization;
using p2.Models.Entities;
using p2.Models.Handler;
namespace p2.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        // GET: Admin/BaseAdmin
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sess = (staff)Session[CommonConstants.ADMIN_SESSION];
            if (sess == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                 new System.Web.Routing.RouteValueDictionary(
                     new
                     {

                         controller = "Home",
                         action = "Index",
                         area = ""
                     }
                ));
            }


            base.OnActionExecuting(filterContext);
        }
    }
}