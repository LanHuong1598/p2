using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2.Models.Entities;
using p2.Models.Handler;
using p2.Models.Function;
using System.IO;

namespace p2.Models.Function
{
    public class F_Student
    {
        DBContext dbcontext;


        public int? update_region(prestudent student)
        {
            // 0 is south, 1 is north 
            dbcontext = new DBContext();

            F_Area f_Area = new F_Area();
            return f_Area.getProvincebycode(student.provincecode).regioncode;
        }

        public double? Cal_TotalMark(prestudent student)
        {
            dbcontext = new DBContext();
            F_enrollment f_Enrollment = new F_enrollment();

            double? total_mark = 0;
            if (f_Enrollment.getNameEnrollment(student.enrollment_code).Equals("A")) // A1
            {
                record record_ = dbcontext.records.Find(student.record_10_1_code);
                total_mark = total_mark + record_.math + record_.physics + record_.chemistry;
                record_ = dbcontext.records.Find(student.record_10_2_code);
                total_mark = total_mark + record_.math + record_.physics + record_.chemistry;
                record_ = dbcontext.records.Find(student.record_11_1_code);
                total_mark = total_mark + record_.math + record_.physics + record_.chemistry;
                record_ = dbcontext.records.Find(student.record_11_2_code);
                total_mark = total_mark + record_.math + record_.physics + record_.chemistry;
                record_ = dbcontext.records.Find(student.record_12_1_code);
                total_mark = total_mark + record_.math + record_.physics + record_.chemistry;
                record_ = dbcontext.records.Find(student.record_12_2_code);
                total_mark = total_mark + record_.math + record_.physics + record_.chemistry;

            }
            else // A1
            {
                record record_ = dbcontext.records.Find(student.record_10_1_code);
                total_mark = total_mark + record_.math + record_.physics + record_.english;
                record_ = dbcontext.records.Find(student.record_10_2_code);
                total_mark = total_mark + record_.math + record_.physics + record_.english;
                record_ = dbcontext.records.Find(student.record_11_1_code);
                total_mark = total_mark + record_.math + record_.physics + record_.english;
                record_ = dbcontext.records.Find(student.record_11_2_code);
                total_mark = total_mark + record_.math + record_.physics + record_.english;
                record_ = dbcontext.records.Find(student.record_12_1_code);
                total_mark = total_mark + record_.math + record_.physics + record_.english;
                record_ = dbcontext.records.Find(student.record_12_2_code);
                total_mark = total_mark + record_.math + record_.physics + record_.english;
            }
            return total_mark;
        }
        public history_update_student getHistory(Guid code)
        {
            dbcontext = new DBContext();
            return dbcontext.history_update_student.Find(code);
        }

        public Guid AddNewStudent(Information_student info_user, string username, string ipaddress, DateTime editdate, string action)
        {

            string rootPath = @"~/Content/StudentImage/";
            dbcontext = new DBContext();
            prestudent us = new prestudent();
            Guid code = Guid.NewGuid();
            us.code = code;


            //Thong tin ca nhân

            var now = editdate;
            string exxfile = now.ToString("dd_MM_yyyy_HH_mm_ss");
            if (info_user.fileimage != null)
            {
                string ex = Path.GetExtension(info_user.fileimage.FileName);
                string target_file = rootPath.Substring(1) + us.code.ToString() + "_" + exxfile + ex;

                string path_image = HttpContext.Current.Server.MapPath(target_file);
                us.image = target_file;
                info_user.fileimage.SaveAs(path_image);

            }

            else
            {
                us.image = "";
            }


            record record10_1 = new record();
            Guid record10_1_code = Guid.NewGuid();

            record10_1.code = record10_1_code;
            record10_1.math = info_user.math_10_1;
            record10_1.chemistry = info_user.chemistry_10_1;
            record10_1.physics = info_user.physic_10_1;
            record10_1.english = info_user.english_10_1;
            if (info_user.school_record_10_1 != null)
            {
                string ex = Path.GetExtension(info_user.school_record_10_1.FileName);
                string target_file = rootPath.Substring(1) + info_user.code.ToString() + "_schoolrecord_10_1" + "_" + exxfile + ex;

                string path_image = HttpContext.Current.Server.MapPath(target_file);
                record10_1.link = target_file;
                info_user.school_record_10_1.SaveAs(path_image);

            }
            else
            {
                record10_1.link = info_user.link_school_record_10_1;

            }



            record record10_2 = new record();
            Guid record10_2_code = Guid.NewGuid();

            record10_2.code = record10_2_code;
            record10_2.math = info_user.math_10_2;
            record10_2.chemistry = info_user.chemistry_10_2;
            record10_2.physics = info_user.physic_10_2;
            record10_2.english = info_user.english_10_2;
            if (info_user.school_record_10_2 != null)
            {
                string ex = Path.GetExtension(info_user.school_record_10_2.FileName);
                string target_file = rootPath.Substring(1) + info_user.code.ToString() + "_schoolrecord_10_2" + "_" + exxfile + ex;

                string path_image = HttpContext.Current.Server.MapPath(target_file);
                record10_2.link = target_file;
                info_user.school_record_10_2.SaveAs(path_image);

            }
            else
            {
                record10_2.link = info_user.link_school_record_10_2;

            }

            record record11_1 = new record();
            Guid record11_1_code = Guid.NewGuid();

            record11_1.code = record11_1_code;

            record11_1.math = info_user.math_11_1;
            record11_1.chemistry = info_user.chemistry_11_1;
            record11_1.physics = info_user.physic_11_1;
            record11_1.english = info_user.english_11_1;
            if (info_user.school_record_11_1 != null)
            {
                string ex = Path.GetExtension(info_user.school_record_11_1.FileName);
                string target_file = rootPath.Substring(1) + info_user.code.ToString() + "_schoolrecord_11_1" + "_" + exxfile + ex;

                string path_image = HttpContext.Current.Server.MapPath(target_file);
                record11_1.link = target_file;
                info_user.school_record_11_1.SaveAs(path_image);

            }
            else
            {
                record11_1.link = info_user.link_school_record_11_1;

            }

            record record11_2 = new record();
            Guid record11_2_code = Guid.NewGuid();

            record11_2.code = record11_2_code;
            record11_2.math = info_user.math_11_2;
            record11_2.chemistry = info_user.chemistry_11_2;
            record11_2.physics = info_user.physic_11_2;
            record11_2.english = info_user.english_11_2;
            if (info_user.school_record_11_2 != null)
            {
                string ex = Path.GetExtension(info_user.school_record_11_2.FileName);
                string target_file = rootPath.Substring(1) + info_user.code.ToString() + "_schoolrecord_11_2" + "_" + exxfile + ex;

                string path_image = HttpContext.Current.Server.MapPath(target_file);
                record11_2.link = target_file;
                info_user.school_record_11_2.SaveAs(path_image);

            }

            else
            {
                record11_2.link = info_user.link_school_record_11_2;

            }
            record record12_1 = new record();
            Guid record12_1_code = Guid.NewGuid();

            record12_1.code = record12_1_code;
            record12_1.math = info_user.math_12_1;
            record12_1.chemistry = info_user.chemistry_12_1;
            record12_1.physics = info_user.physic_12_1;
            record12_1.english = info_user.english_12_1;

            if (info_user.school_record_12_1 != null)
            {
                string ex = Path.GetExtension(info_user.school_record_12_1.FileName);
                string target_file = rootPath.Substring(1) + info_user.code.ToString() + "_schoolrecord_12_1" + "_" + exxfile + ex;

                string path_image = HttpContext.Current.Server.MapPath(target_file);
                record12_1.link = target_file;
                info_user.school_record_12_1.SaveAs(path_image);

            }
            else
            {
                record12_1.link = info_user.link_school_record_12_1;

            }
            record record12_2 = new record();
            Guid record12_2_code = Guid.NewGuid();

            record12_2.code = record12_2_code;
            record12_2.math = info_user.math_12_2;
            record12_2.chemistry = info_user.chemistry_12_2;
            record12_2.physics = info_user.physic_12_2;
            record12_2.english = info_user.english_12_2;

            if (info_user.school_record_12_2 != null)
            {
                string ex = Path.GetExtension(info_user.school_record_12_2.FileName);
                string target_file = rootPath.Substring(1) + info_user.code.ToString() + "_schoolrecord_12_2" + "_" + exxfile + ex;
                record12_2.link = target_file;
                string path_image = HttpContext.Current.Server.MapPath(target_file);

                info_user.school_record_12_2.SaveAs(path_image);

            }
            else
            {
                record12_2.link = info_user.link_school_record_12_2;

            }


            try
            {
                dbcontext.records.Add(record10_1);
                dbcontext.records.Add(record10_2);
                dbcontext.records.Add(record11_1);
                dbcontext.records.Add(record11_2);
                dbcontext.records.Add(record12_1);
                dbcontext.records.Add(record12_2);

                dbcontext.SaveChanges();

            }
            catch
            {

            }

            us.date_of_birth = info_user.date_of_birth;
            us.place_of_birth = info_user.place_of_birth;
            us.school_address_10 = info_user.school_address_10;
            us.school_address_11 = info_user.school_address_11;
            us.school_address_12 = info_user.school_address_12;
            us.phone_of_parent = info_user.phone_of_parent;
            us.name_of_receiver = info_user.name_of_receiver;
            us.school_year = info_user.school_year;
            us.regionmark_code = info_user.regionmark_code;
            us.ethnic = info_user.ethnic;
            us.name = info_user.name;
            us.districtcode = info_user.districtcode;
            us.provincecode = info_user.provincecode;
            us.towncode = info_user.towncode;
            us.sex = info_user.sex;
            us.school_year = info_user.school_year;
            us.email = info_user.email;
            us.phone = info_user.phone;
            us.place_of_birth = info_user.place_of_birth;
            us.statusmark_code = info_user.statusmark_code;
            us.identity_card = info_user.identity_card;
            us.village = info_user.village;
            us.enrollment_code = info_user.enrollment_code;
            us.address = info_user.address;
            string[] nameList = info_user.name.Split(' ');
            if (nameList != null)
                us.first_name = nameList[nameList.Length - 1];
            if (nameList.Length >= 2)
                us.middle_name = nameList[nameList.Length - 2];
            us.last_name = "";

            for (int i = 0; i < nameList.Length - 2; i++)
                us.last_name = us.last_name + " " + nameList[i];

            //Ket qua hoc tap
            us.record_10_1_code = record10_1_code;
            us.record_10_2_code = record10_2_code;
            us.record_11_1_code = record11_1_code;
            us.record_11_2_code = record11_2_code;
            us.record_12_1_code = record12_1_code;
            us.record_12_2_code = record12_2_code;
            //dbcontext.Entry(us).State = EntityState.Modified;

            history_update_student his_student = new history_update_student();
            

            // update account

            // cal total mark
            F_Student f_Student = new F_Student();
            us.totalmark = f_Student.Cal_TotalMark(us);

            // update region
            us.region = f_Student.update_region(us);
            us.active = 1;
            dbcontext.prestudents.Add(us);
            dbcontext.SaveChanges();
            his_student = new F_User().make_history_student(us, username, ipaddress, editdate, action);
            dbcontext.history_update_student.Add(his_student);
            dbcontext.SaveChanges();
            return code;





        }


    }
}