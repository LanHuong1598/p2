using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2.Models.Entities;
namespace p2.Authorization
{
    public class CookiesManage
    {
        public static prestudent getPreStudent()
        {
            prestudent user = new prestudent();
            var cookiesClient = (prestudent)HttpContext.Current.Session[CommonConstants.USER_SESSION];
            if (cookiesClient != null)
            {
                user = cookiesClient;
                return user;
            }
            else
            {
                return null;
            }
          
        }
        public static user getUser()
        {
            user us = new user();
            var cookiesClient = (user)HttpContext.Current.Session[CommonConstants.USER_SESSION];
            if(cookiesClient!=null)
            {
                us = cookiesClient;
                return us;
            }
            else
            {
                return null;
            }
           
        }
        public static staff getAdmin()
        {
            staff us = new staff();
            var cookiesClient = (staff)HttpContext.Current.Session[CommonConstants.ADMIN_SESSION];
            if (cookiesClient != null)
            {
                us = cookiesClient;
                return us;
            }
            else
            {
                return null;
            }

        }
    }
}