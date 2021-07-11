using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2.Models.Entities;
namespace p2.Authorization
{
    public class CookiesManage
    {
        public static imformation_user getUser()
        {
            imformation_user user = new imformation_user();
            var cookiesClient = (imformation_user)HttpContext.Current.Session[CommonConstants.USER_SESSION];
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
    }
}