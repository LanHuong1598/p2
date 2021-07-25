using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2.Models.Entities;
using p2.Models.Handler;
using System.IO;
using System.Drawing;

namespace p2.Models.Function
{
    public class F_User
    {
        DBContext dbcontext = new DBContext();
        public List<prestudent> getUsers()
        {
            dbcontext = new DBContext();
            return dbcontext.prestudents.ToList();
        }

        public List<user> getListUser()
        {
            dbcontext = new DBContext();
            return dbcontext.users.ToList();
        }
        public prestudent getByID(Guid? id)
        {
            dbcontext = new DBContext();
            return dbcontext.prestudents.Find(id);
        }
        public int checkIdentityCard(user account)
        {
            dbcontext = new DBContext();
            string identity = dbcontext.prestudents.Find(account.prestudent_code).identity_card;
            var check = dbcontext.prestudents.Where(x => x.identity_card == identity);
            if (identity == null)
            {
                return 1;
            }
            if (check.Count()>1)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        public bool Login(string username, string passwrod)
        {
            bool status = false;
            dbcontext = new DBContext();
          
            string encode = CryptorEngine.Encrypt(passwrod);
            var account = dbcontext.users.Where(x => x.username == username && x.password == encode);
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
        public bool LoginAdmin(string username, string password)
        {
            bool status = false;
            dbcontext = new DBContext();

            string encode = CryptorEngine.Encrypt(password);
            var account = dbcontext.staffs.Where(x => x.username == username && x.password == encode);
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
        public staff getUserLoginAdmin(string username, string password)
        {
            dbcontext = new DBContext();
            password = CryptorEngine.Encrypt(password);
            var acccount = dbcontext.staffs.SingleOrDefault(x => x.username == username && x.password == password);
            return acccount;
        }
        public string Register(user account, string password_confirm, string ipaddress)
        {
            var check_username = dbcontext.users.Where(x => x.username==account.username);

            var check_identity_card = dbcontext.users.Where(x => x.identity_card.Equals(account.identity_card));

            string result = "";
            if (check_username.Count() != 0)
            {
                result = result + "Đã tồn tại username/";
            }

            if (account.password != password_confirm)
            {
                result = result + "Mật khẩu không trùng/";
            }
           
            if (result != "")
            {
                return result;
            }

            prestudent student = new prestudent();
            // make code
            Guid code = Guid.NewGuid();
            student.code = code;
            // copy to user
            student.phone = account.phone;
            student.identity_card = account.identity_card;
            student.name = account.name;
            // split name
            string[] nameList = account.name.Split(' ');
            if (nameList != null)
                student.first_name = nameList[nameList.Length - 1];
            if (nameList.Length >= 2)
                student.middle_name = nameList[nameList.Length - 2];
            student.last_name = "";

            for (int i = 0; i < nameList.Length - 2; i++)
                student.last_name = student.last_name + " " + nameList[i];

            
            //Tạo bản ghi học bạ
            Guid record10_1_code = Guid.NewGuid();
            record record10_1 = new record();
            record10_1.code = record10_1_code;
            student.record_10_1_code = record10_1_code;
            dbcontext.records.Add(record10_1);

            Guid record10_2_code = Guid.NewGuid();
            record record10_2 = new record();
            record10_2.code = record10_2_code;
            student.record_10_2_code = record10_2_code;
            dbcontext.records.Add(record10_2);

            Guid record11_1_code = Guid.NewGuid();
            record record11_1 = new record();
            record11_1.code = record11_1_code;
            student.record_11_1_code = record11_1_code;
            dbcontext.records.Add(record11_1);

            Guid record11_2_code = Guid.NewGuid();
            record record11_2 = new record();
            record11_2.code = record11_2_code;
            student.record_11_2_code = record11_2_code;
            dbcontext.records.Add(record11_2);

            Guid record12_1_code = Guid.NewGuid();
            record record12_1 = new record();
            record12_1.code = record12_1_code;
            student.record_12_1_code = record12_1_code;
            dbcontext.records.Add(record12_1);

            Guid record12_2_code = Guid.NewGuid();
            record record12_2 = new record();
            record12_2.code = record12_2_code;
            student.record_12_2_code = record12_2_code;
            dbcontext.records.Add(record12_2);
            // add account

            string password = account.password;
            password = CryptorEngine.Encrypt(password);
            account.password = password;
            account.prestudent_code = code;
            student.address = account.address;
            Guid code_acc = Guid.NewGuid();
            account.code = code_acc;
            dbcontext.users.Add(account);
            dbcontext.SaveChanges();
            dbcontext.prestudents.Add(student);
            dbcontext.SaveChanges();
            history_update_student his_student = new history_update_student();
            his_student = make_history_student(student, account.username, ipaddress, DateTime.Now, "Create");
            

            dbcontext.history_update_student.Add(his_student);
            try
            {
                dbcontext.SaveChanges();
            }
            catch
            {
                return "Thất bại/";
            }
            return "Thành công";
        }
        

        public prestudent make_update_prestudent(Information_student info_user)
        {
            prestudent student = new prestudent();
            return student;
        }

        public string update_Information(Information_student info_user, string username, string ipaddress, DateTime editdate, string action)
        {
            string rootPath = @"~/Content/StudentImage/" ;
            dbcontext = new DBContext();
            prestudent us = new prestudent();
            us = dbcontext.prestudents.Find(info_user.code);


            //Thong tin ca nhân

            var now = editdate;
            string exxfile = now.ToString("dd_MM_yyyy_HH_mm_ss");
            if (info_user.fileimage != null)
            {
                string ex = Path.GetExtension(info_user.fileimage.FileName);
                string target_file = rootPath.Substring(1) + info_user.code.ToString() + "_" + exxfile + ex;

                string path_image = HttpContext.Current.Server.MapPath(target_file);
                us.image = target_file;
                info_user.fileimage.SaveAs(path_image);

            }

            else
            {
                us.image = info_user.image;
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
            if(info_user.school_record_11_2 != null)
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

            if(info_user.school_record_12_1 != null)
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
                return "Thất bại";
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
            his_student = make_history_student(us, username, ipaddress, editdate, action);
            dbcontext.history_update_student.Add(his_student);
            dbcontext.SaveChanges();

            // update account
            var account_login = dbcontext.users.Single(x => x.prestudent_code == info_user.code);
            account_login.identity_card = us.identity_card;
            account_login.name = us.name;
            account_login.phone = us.phone;
            account_login.address = us.address;
            account_login.email = us.email;

            // cal total mark
            F_Student f_Student = new F_Student();
            us.totalmark = f_Student.Cal_TotalMark(us);

            // update region
            us.region = f_Student.update_region(us);
            us.active = 1;
            dbcontext.SaveChanges();
            
            return "Thành công";


            
            
        }
        public history_update_student make_history_student(prestudent student,string username, string ipaddress, DateTime editdate, string action)
        {

            history_update_student history_student = new history_update_student();
            history_student.prestudentcode = student.code;
            history_student.address = student.address;
            history_student.armycheckid = student.armycheckid;
            history_student.candidateid = student.candidateid;
            history_student.date_of_birth = student.date_of_birth;
            history_student.districtcode = student.districtcode;
            history_student.edit_date = DateTime.Now;
            history_student.email = student.email;
            history_student.enrollment_code = student.enrollment_code;
            history_student.ethnic = student.ethnic;
            history_student.first_name = student.first_name;
            history_student.image = student.image;
            history_student.last_name = student.last_name;
            history_student.middle_name = student.middle_name;
            history_student.name = student.name;
            history_student.phone = student.phone;
            history_student.place_of_birth = student.place_of_birth;
            history_student.provincecode = student.provincecode;
            history_student.record_10_1_code = student.record_10_1_code;
            history_student.record_10_2_code = student.record_10_2_code;
            history_student.record_11_1_code = student.record_11_1_code;
            history_student.record_11_2_code = student.record_11_2_code;
            history_student.record_12_1_code = student.record_12_1_code;
            history_student.record_12_2_code = student.record_12_2_code;
            history_student.region = student.region;
            history_student.regionmark_code = student.regionmark_code;
            history_student.school_address_10 = student.school_address_10;
            history_student.school_address_11 = student.school_address_11;
            history_student.school_address_12 = student.school_address_12;
            history_student.sex = student.sex;
            history_student.statusmark_code = student.statusmark_code;
            history_student.totalmark = student.totalmark;
            history_student.towncode = student.towncode;
            history_student.village = student.village;
            Guid code = Guid.NewGuid();
            history_student.code = code;
            history_student.edit_by_user = username;
            history_student.edit_by_ip = ipaddress;
            history_student.edit_date = editdate;
            history_student.action = action;


            return history_student;
        }
        public Information_student getInformationStudent(Guid prestudentcode)
        {
            dbcontext = new DBContext();
            Information_student infor = new Information_student();
            prestudent student = new prestudent();
            student = dbcontext.prestudents.Find(prestudentcode);

            infor.address = student.address;
            infor.armycheckid = student.armycheckid;
            infor.candidateid = student.candidateid;
            infor.code = student.code;
            infor.date_of_birth = student.date_of_birth;
            infor.place_of_birth = student.place_of_birth;
            infor.districtcode = student.districtcode;
            infor.enrollment_code = student.enrollment_code;
            infor.email = student.email;
            infor.ethnic = student.ethnic;
            infor.image = student.image;
            infor.last_name = student.last_name;
            infor.first_name = student.first_name;
            infor.middle_name = student.middle_name;
            infor.name = student.name;
            infor.identity_card = student.identity_card;
            infor.phone = student.phone;
            infor.name_of_receiver = student.name_of_receiver;
            infor.phone_of_parent = student.phone_of_parent;
            infor.region = student.region;
            infor.regionmark_code = student.regionmark_code;
            infor.provincecode = student.provincecode;
            infor.totalmark = student.totalmark;
            infor.towncode = student.towncode;
            infor.sex = student.sex;
            infor.statusmark_code = student.statusmark_code;
            infor.village = student.village;
            infor.school_address_10 = student.school_address_10;
            infor.school_address_11 = student.school_address_11;
            infor.school_address_12 = student.school_address_12;
            infor.school_year = student.school_year;
            record record10_1 = new record();
            record10_1 = dbcontext.records.Find(student.record_10_1_code);
            infor.math_10_1 = record10_1.math;
            infor.chemistry_10_1 = record10_1.chemistry;
            infor.physic_10_1 = record10_1.physics;
            infor.english_10_1 = record10_1.english;
            infor.link_school_record_10_1 = record10_1.link;
            infor.record_10_1_code = student.record_10_1_code;

            record record10_2 = new record();
            record10_2 = dbcontext.records.Find(student.record_10_2_code);
            infor.math_10_2 = record10_2.math;
            infor.chemistry_10_2 = record10_2.chemistry;
            infor.physic_10_2 = record10_2.physics;
            infor.english_10_2 = record10_2.english;
            infor.link_school_record_10_2 = record10_2.link;
            infor.record_10_2_code = student.record_10_2_code;

            record record11_1 = new record();
            record11_1 = dbcontext.records.Find(student.record_11_1_code);
            infor.math_11_1 = record11_1.math;
            infor.chemistry_11_1 = record11_1.chemistry;
            infor.physic_11_1 = record11_1.physics;
            infor.english_11_1 = record11_1.english;
            infor.link_school_record_11_1 = record11_1.link;
            infor.record_11_1_code = student.record_11_1_code;

            record record11_2 = new record();
            record11_2 = dbcontext.records.Find(student.record_11_2_code);
            infor.math_11_2 = record11_2.math;
            infor.chemistry_11_2 = record11_2.chemistry;
            infor.physic_11_2 = record11_2.physics;
            infor.english_11_2 = record11_2.english;
            infor.link_school_record_11_2 = record11_2.link;
            infor.record_11_2_code = student.record_11_2_code;

            record record12_1 = new record();
            record12_1 = dbcontext.records.Find(student.record_12_1_code);
            infor.math_12_1 = record12_1.math;
            infor.chemistry_12_1 = record12_1.chemistry;
            infor.physic_12_1 = record12_1.physics;
            infor.english_12_1 = record12_1.english;
            infor.link_school_record_12_1 = record12_1.link;
            infor.record_12_1_code = student.record_12_1_code;

            record record12_2 = new record();
            record12_2 = dbcontext.records.Find(student.record_12_2_code);
            infor.math_12_2 = record12_2.math;
            infor.chemistry_12_2 = record12_2.chemistry;
            infor.physic_12_2 = record12_2.physics;
            infor.english_12_2 = record12_2.english;
            infor.link_school_record_12_2 = record12_2.link;
            infor.record_12_2_code = student.record_12_2_code;
            infor.active = student.active;

            return infor; 

        }
        public string upload_image()
        {
            return "Thành công";
        }

        public prestudent getPrestudentByUser(user us)
        {
            dbcontext = new DBContext();
            Guid? code = us.prestudent_code;
            var student = dbcontext.prestudents.Find(code);
            return student;
        }
        public user getUserLogin(string username, string password)
        {
            dbcontext = new DBContext();
            password = CryptorEngine.Encrypt(password);
            var acccount = dbcontext.users.SingleOrDefault(x => x.username == username && x.password == password);
            return acccount;
        }
        public prestudent GetPrestudentByLogin(string username, string password)
        {
            dbcontext = new DBContext();
            password = CryptorEngine.Encrypt(password);
            var acccount = dbcontext.users.SingleOrDefault(x => x.username == username && x.password == password);
            prestudent student = new prestudent();
            Guid? code;
            code = acccount.prestudent_code;
            student = dbcontext.prestudents.Find(code);
            return student;
        }

        public string ChangePassword(Guid user_code, string password_old, string password_new,string confirmpassword_new)
        {

            
            string result = "";
            dbcontext = new DBContext();
            var user_ = dbcontext.users.Find(user_code);
            string pass_ = user_.password;
            password_old = CryptorEngine.Encrypt(password_old);
            if (password_old != pass_)
            {
                return "Mật khẩu cũ không đúng";
            }
            if (password_new != confirmpassword_new)
            {
                return "Nhập mật khẩu không trùng";
            }
            string encode_pass_new = CryptorEngine.Encrypt(password_new);
            user_.password = encode_pass_new;
            dbcontext.SaveChanges();
            return "Thành công";

        }
        
        public user getUserbyCode(Guid code)
        {
            dbcontext = new DBContext();
            return dbcontext.users.Find(code);
        }

        public int ResetPassword(Guid code, string password_new)
        {
            dbcontext = new DBContext();
            var acc = dbcontext.users.Find(code);
            acc.password = CryptorEngine.Encrypt(password_new);
            try{
                dbcontext.SaveChanges();
                return 1;
            }
            catch
            {
                return -1;
            }
        }
    }
}