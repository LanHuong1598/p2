using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2.Models.Entities;
namespace p2.Models.Function
{
    public class F_User
    {
        DBContext dbcontext;
        public string Register(account_user account, string password_confirm)
        {
            dbcontext = new DBContext();
            string id = account.id;
            string email = account.email;
            var check_cmnd = dbcontext.account_user.Where(x => x.id == id);
            if (account.password != password_confirm)
            {
                return "Mật khẩu không trùng";
            }
            if (check_cmnd.Count() > 0)
            {
                return "Số CMND đã được đăng ký";
            }
            var check_email = dbcontext.account_user.Where(x => x.email == email);
            if (check_email.Count() >0)
            {
                return "Email đã được đăng ký";
            }
            string password = account.password;
            password = CryptorEngine.Encrypt(password);
            account.password = password;
            dbcontext.account_user.Add(account);
            imformation_user user = new imformation_user();
            user.id = account.id;
            user.email = account.email;
            dbcontext.imformation_user.Add(user);
            try
            {
                
                string path = HttpContext.Current.Server.MapPath("~Content/StudentImage/");
                if (!System.IO.Directory.Exists(path + account.id.ToString()))
                    {
                    System.IO.Directory.CreateDirectory(path + account.id.ToString());
                }
                dbcontext.SaveChanges();
            }
            catch
                {
                return "Thất bại";
            }
            return "Thành công";
        }
        public string update_Information(imformation_user info_user, HttpPostedFile avatar, HttpPostedFile school_profile)
        {
            dbcontext = new DBContext();
            string email = info_user.email;
            var temp = dbcontext.imformation_user.Where(x => x.email == email);
            if (temp.Count() !=0)
            {
                return "Email đã trùng";
            }
            if (avatar != null)
            {
                info_user.image = avatar.FileName;
            }
            /*
            if (school_profile != null)
            {
                info_user.
            }
            */
            imformation_user user = new imformation_user();
            user = dbcontext.imformation_user.Single(x => x.id == info_user.id);
            user = info_user;
            dbcontext.SaveChanges();


             
            return "Thành công";
        }

        public string upload_image()
        {
            return "Thành công";
        }
    }
}