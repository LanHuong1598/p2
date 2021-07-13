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
using System.Data.SqlClient;

namespace p2.Models.Function
{
    public class F_User
    {
        DBContext dbcontext = new DBContext();
        public List<imformation_user> getUsers()
        {
            dbcontext = new DBContext();
            return dbcontext.imformation_user.ToList();
        }
        public imformation_user getByID(string id)
        {
            dbcontext = new DBContext();
            return dbcontext.imformation_user.Find(id);
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
            user.name = account.name;
            string[] nameList = account.name.Split(' ');
            if (nameList != null)
                user.first_name = nameList[nameList.Length - 1];
            if (nameList.Length >= 2)
                user.middle_name = nameList[nameList.Length - 2];
            user.last_name = "";
            for (int i = 0; i < nameList.Length - 2; i++)
                user.last_name = user.last_name + " " + nameList[i];
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
        public List<imformation_user> make_exam_identification_number()
        {

            dbcontext = new DBContext();
            limit_candidate limit_candidate = dbcontext.limit_candidate.First();

            dbcontext.Database.SqlQuery<string>("update imformation_user set exam_id = null, lock_ = 0, room_id = null");

            // mien bac
            List<get_imfor_for_make_exam_id> list = dbcontext.Database.SqlQuery<get_imfor_for_make_exam_id>("exec make_exam_id @param1, @param2, 0",
                new SqlParameter("param1", limit_candidate.male_north),
                new SqlParameter("param2", limit_candidate.female_north)
             ).ToList();

            foreach (var e in list)
            {
                if (e.lock_ == 0)
                {
                    imformation_user us = dbcontext.imformation_user.Find(e.id);
                    string myString = e.exam_id.ToString();
                    while (myString.Length < 6) myString = "0" + myString;
                    us.exam_id = myString;
                    us.lock_ = 1;
                    dbcontext.SaveChanges();
                }
            }

            // mien nam
            int begin = list.Count();
            list = dbcontext.Database.SqlQuery<get_imfor_for_make_exam_id>("exec make_exam_id @param1, @param2, 1",
               new SqlParameter("param1", limit_candidate.male_south),
               new SqlParameter("param2", limit_candidate.female_south)
            ).ToList();

            foreach (var e in list)
            {
                //if (e.lock_ == 0)
                {
                    imformation_user us = dbcontext.imformation_user.Find(e.id);
                    string myString = (begin + 10 + e.exam_id).ToString();
                    while (myString.Length < 6) myString = "0" + myString;
                    us.exam_id = myString;
                    //us.lock_ = 1;
                    dbcontext.SaveChanges();
                }
            }
            // phan phong thi
            List<imformation_user> results = dbcontext.Database.SqlQuery<imformation_user>("select * from imformation_user where exam_id is not null order by exam_id").ToList();

            List<room> rooms = dbcontext.rooms.ToList();
            int room_ = -1;
            for (int i = 0; i < results.Count; i++)
            {
                if (i % 5 == 0) room_++;
                imformation_user us = dbcontext.imformation_user.Find(results[i].id);
                us.room_id = rooms[room_].name;
                //us.lock_ = 1;
                dbcontext.SaveChanges();

            }
            return results;
        }
        public string update_Information(imformation_user info_user, SchoolRecord record)
        {
            string rootPath = @"~/Content/StudentImage/" + info_user.id.ToString();
            dbcontext = new DBContext();
            imformation_user us = new imformation_user();
            us = dbcontext.imformation_user.Find(info_user.id);

            if (record.fileimage != null && (info_user.image != null || info_user.image !=""))
            {
                
                string ex = Path.GetExtension(record.fileimage.FileName);
                string target_file = rootPath.Substring(1) + ex;

                string path_image = HttpContext.Current.Server.MapPath(target_file);
                
                record.fileimage.SaveAs(path_image);

                info_user.image = target_file;
                us.image = info_user.image;
            }
            if (record.school_record_10_1!=null && (info_user.school_record_10_1 != null || info_user.school_record_10_1 != ""))
            {
                string ex = Path.GetExtension(record.school_record_10_1.FileName);
                string target_file = rootPath.Substring(1) + "_school_record_10_1" + ex;
                string path_image = HttpContext.Current.Server.MapPath(target_file);
               
                record.school_record_10_1.SaveAs(path_image);
                info_user.school_record_10_1 = target_file;
                us.school_record_10_1 = target_file;
            }

            if (record.school_record_10_2 != null && (info_user.school_record_10_2 != null || info_user.school_record_10_2 != ""))
            {
                string ex = Path.GetExtension(record.school_record_10_2.FileName);
                string target_file = rootPath.Substring(1) + "_school_record_10_2" + ex;
                string path_image = HttpContext.Current.Server.MapPath(target_file);

                record.school_record_10_2.SaveAs(path_image);
                us.school_record_10_2 = target_file;
            }
            if (record.school_record_11_1 != null && (info_user.school_record_11_1 != null || info_user.school_record_11_1 != "")) 
            {
                string ex = Path.GetExtension(record.school_record_11_1.FileName);

                string target_file = rootPath.Substring(1) + "_school_record_11_1" + ex;
                string path_image = HttpContext.Current.Server.MapPath(target_file);

                record.school_record_11_1.SaveAs(path_image);
                us.school_record_11_1 = target_file;
                
            }
            if (record.school_record_11_2 != null && (info_user.school_record_11_2 != null || info_user.school_record_11_2 != ""))
            {

                string ex = Path.GetExtension(record.school_record_11_2.FileName);
                string target_file = rootPath.Substring(1) + "_school_record_11_2" + ex;
                string path_image = HttpContext.Current.Server.MapPath(target_file);

                record.school_record_11_2.SaveAs(path_image);
                us.school_record_11_2 = target_file;
            }
            if (record.school_record_12_1 != null && (info_user.school_record_12_1 != null || info_user.school_record_12_1 != ""))
            {
                string ex = Path.GetExtension(record.school_record_12_1.FileName);
                string target_file = rootPath.Substring(1) + "_school_record_12_1" + ex;
                string path_image = HttpContext.Current.Server.MapPath(target_file);

                record.school_record_12_1.SaveAs(path_image);
                us.school_record_12_1 = target_file;
            }
            if (record.school_record_12_2 != null && (info_user.school_record_12_2 != null || info_user.school_record_12_2 != ""))
            {

                string ex = Path.GetExtension(record.school_record_12_2.FileName);
                string target_file = rootPath.Substring(1) + "_school_record_12_2" + ex;
                string path_image = HttpContext.Current.Server.MapPath(target_file);

                record.school_record_12_2.SaveAs(path_image);
                us.school_record_12_2 = target_file;
            }
            try
            {
                if (us.admission_group == 1)
                {
                    us.total_mark = us.math_10_1 + us.math_10_2 + us.math_11_1 + us.math_11_2 + us.math_12_1 + us.math_12_2 +
                        us.chemistry_10_1 + us.chemistry_10_2 + us.chemistry_11_1 + us.chemistry_11_2 + us.chemistry_12_1 + us.chemistry_12_2 +
                        us.physic_10_1 + us.physic_10_2 + us.physic_11_1 + us.physic_11_2 + us.physic_12_1 + us.physic_12_2;
                }
                else
                {

                    us.total_mark = us.math_10_1 + us.math_10_2 + us.math_11_1 + us.math_11_2 + us.math_12_1 + us.math_12_2 +
                        us.english_10_1 + us.english_10_2 + us.english_11_1 + us.english_11_2 + us.english_12_1 + us.english_12_2 +
                        us.physic_10_1 + us.physic_10_2 + us.physic_11_1 + us.physic_11_2 + us.physic_12_1 + us.physic_12_2;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            //dbcontext.Entry(us).State = EntityState.Modified;
            //Thong tin ca nhân
            us.ethnic = info_user.ethnic;
            us.name = info_user.name;
           
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
            us.priority_object = info_user.priority_object;
            us.admission_group = info_user.admission_group;
            us.area_object = info_user.area_object;
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