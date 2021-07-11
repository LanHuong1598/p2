using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2.Models.Entities;
using p2.Authorization;
using System.Web.UI;
using System.Web.Mvc;
using p2.Models.Handler;
using System.IO;
using System.Data.Entity;

namespace p2.Models.Function
{
    public class F_User
    {
        DBContext dbcontext = new DBContext();
        public imformation_user getByID(string id)
        {
            dbcontext = new DBContext();
            return dbcontext.imformation_user.SingleOrDefault(x => x.id == id);
        }
        public bool Login(string id, string passwrod)
        {
            bool status = false;
            dbcontext = new DBContext();
          
            string encode = CryptorEngine.Encrypt(passwrod);
            var account = dbcontext.account_user.Where(x => x.id == id && x.password == encode);
            if (account.Count() == 0)
            {
                return status;
            }
            else
            {
               
                status = true;
                return status;
            }
        
        }
        public string Register(account_user account, string password_confirm)
        {
            
            string id = account.id;
            string email = account.email;
            var check_cmnd = dbcontext.account_user.Where(x => x.id == id);
            string result = "";
            if (account.password != password_confirm)
            {
                result = result + "Mật khẩu không trùng/";
            }
            if (check_cmnd.Count() > 0)
            {
                result = result + "Số CMND đã được đăng ký/";
            }
            var check_email = dbcontext.account_user.Where(x => x.email == email);
            if (check_email.Count() >0)
            {
                result = result + "Email đã được đăng ký";
            }
            if (result != "")
            {
                return result;
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
                
                string path = HttpContext.Current.Server.MapPath("~/Content/StudentImage/");
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
        public string update_Information(imformation_user info_user, SchoolRecord record)
        {
            string rootPath = @"~/Content/StudentImage/" + info_user.id.ToString();
            dbcontext = new DBContext();
            if(record.fileimage != null)
            {
                
                string ex = Path.GetExtension(record.fileimage.FileName);
                string path_image = HttpContext.Current.Server.MapPath(rootPath);
                record.fileimage.SaveAs(path_image + ex);
               
                info_user.image = rootPath.Substring(1) + ex;
            }
            if (record.school_record_10_1!=null)
            {
                string ex = Path.GetExtension(record.school_record_10_1.FileName);
                string target_file = rootPath.Substring(1) + "_school_record_10_1" + ex;
                string path_image = HttpContext.Current.Server.MapPath(target_file);
               
                record.fileimage.SaveAs(path_image);
                info_user.school_record_10_1 = target_file;
            }

            if (record.school_record_10_2 != null)
            {
                string ex = Path.GetExtension(record.school_record_10_2.FileName);
                string target_file = rootPath.Substring(1) + "_school_record_10_2" + ex;
                string path_image = HttpContext.Current.Server.MapPath(target_file);

                record.fileimage.SaveAs(path_image);
                info_user.school_record_10_2 = target_file;
            }
            if (record.school_record_11_1 != null)
            {
                string ex = Path.GetExtension(record.school_record_11_1.FileName);

                string target_file = rootPath.Substring(1) + "_school_record_11_1" + ex;
                string path_image = HttpContext.Current.Server.MapPath(target_file);

                record.fileimage.SaveAs(path_image);
                info_user.school_record_11_1 = target_file;
            }
            if (record.school_record_11_2 != null)
            {

                string ex = Path.GetExtension(record.school_record_11_2.FileName);
                string target_file = rootPath.Substring(1) + "_school_record_11_2" + ex;
                string path_image = HttpContext.Current.Server.MapPath(target_file);

                record.fileimage.SaveAs(path_image);
                info_user.school_record_11_2 = target_file;
            }
            if (record.school_record_12_1 != null)
            {
                string ex = Path.GetExtension(record.school_record_12_1.FileName);
                string target_file = rootPath.Substring(1) + "_school_record_12_1" + ex;
                string path_image = HttpContext.Current.Server.MapPath(target_file);

                record.fileimage.SaveAs(path_image);
                info_user.school_record_12_1 = target_file;
            }
            if (record.school_record_12_2 != null)
            {

                string ex = Path.GetExtension(record.school_record_12_2.FileName);
                string target_file = rootPath.Substring(1) + "_school_record_12_2" + ex;
                string path_image = HttpContext.Current.Server.MapPath(target_file);

                record.fileimage.SaveAs(path_image);
                info_user.school_record_12_2 = target_file;
            }
            imformation_user us = new imformation_user();
            us = dbcontext.imformation_user.SingleOrDefault(x=>x.id == info_user.id);
            //Thong tin ca nhân
            us.ethnic = info_user.ethnic;
            us.name = info_user.name;
            us.image = info_user.image;
            us.area = info_user.area;
            us.area_of_receiver = info_user.area_of_receiver;
            us.candidate_number = info_user.candidate_number;
            us.date_of_birth = info_user.date_of_birth;
            us.email = info_user.email;
            us.name_of_receiver = info_user.name_of_receiver;
            us.permanent_residence = info_user.permanent_residence;
            us.phone = info_user.phone;
            us.sex = info_user.sex;
            us.phone_of_parent = info_user.phone_of_parent;
            us.place_of_study_10 = info_user.place_of_study_10;
            us.place_of_study_11 = info_user.place_of_study_11;
            us.place_of_study_12 = info_user.place_of_study_12;
            us.place_of_birth = info_user.place_of_birth;
            
            //Ket qua hoc tap
            us.chemistry_10_1 = info_user.chemistry_10_1;
            us.math_10_1 = info_user.math_10_1;
            us.physic_10_1 = info_user.physic_10_1;
            us.english_10_1 = info_user.english_10_1;
            us.math_10_2 = info_user.math_10_2;
            us.english_10_2 = info_user.english_10_2;
            us.chemistry_10_2 = info_user.chemistry_10_2;
            us.physic_10_2 = info_user.physic_10_2;
            us.math_11_1 = info_user.math_11_1;
            us.chemistry_11_1 = info_user.chemistry_11_1;
            us.english_11_1 = info_user.english_11_1;
            us.physic_11_1 = info_user.physic_11_1;
            us.math_11_2 = info_user.math_11_2;
            us.physic_11_2 = info_user.physic_11_2;
            us.chemistry_11_2 = info_user.chemistry_11_2;
            us.english_11_2 = info_user.english_11_2;
            us.math_12_1 = info_user.math_12_1;
            us.chemistry_12_1 = info_user.chemistry_12_1;
            us.physic_12_1 = info_user.physic_12_1;
            us.english_12_1 = info_user.english_12_1;
            us.math_12_2 = info_user.math_12_2;
            us.chemistry_12_2 = info_user.chemistry_12_2;
            us.physic_12_2 = info_user.physic_12_2;
            us.english_12_2 = info_user.english_12_2;
            us.year_of_graduation = info_user.year_of_graduation;
            us.school_record_10_1 = info_user.school_record_10_1;
            us.school_record_10_2 = info_user.school_record_10_2;
            us.school_record_11_2 = info_user.school_record_11_2;
            us.school_record_11_1 = info_user.school_record_11_1;
            us.school_record_12_1 = info_user.school_record_12_1;
            us.school_record_12_2 = info_user.school_record_12_2;
            //dbcontext.Entry(us).State = EntityState.Modified;


            dbcontext.SaveChanges();
            return "Thành công";
            
            
        }

        
        public string upload_image()
        {
            return "Thành công";
        }
    }
}