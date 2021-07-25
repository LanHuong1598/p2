using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2.Models.Entities;
using p2.Areas.Admin.Models.Handler;
using System.Data.SqlClient;

namespace p2.Areas.Admin.Models.Function
{
    public class F_Candidate
    {
        DBContext dbcontext = new DBContext();

        // thong ke theo mien bac, nam, 
        public Statistic_Student stats()
        {
            dbcontext = new DBContext();
            return dbcontext.Database.SqlQuery<Statistic_Student>("statistic_prestudent_region_and_sex").ToList().First();
        }


        public List<SummaryInformation> getInfor()
        {
            
            List<SummaryInformation> summaryInformation = new List<SummaryInformation>();
            var liststudent = dbcontext.prestudents.ToList();
            foreach (var item in liststudent)
            {
                SummaryInformation info = new SummaryInformation();
                info.code = item.code;
                info.name = item.name;
                info.permanent_residence = getPermanent_residence(item.towncode);
                info.sex = item.sex;
                info.totalmark = Math.Round(Convert.ToDouble(item.totalmark)/6, 2);
                string date = item.date_of_birth.ToString();
                if (date != "" && date != null)
                {
                    string day = date.Split('/')[0];
                    string month = date.Split('/')[1];
                    string year = date.Split('/')[2].Split(' ')[0];

                    info.date_of_birth = day + " / " + month + " / " + year;
                }
                else
                {
                    info.date_of_birth = date;
                }


                info.enrolment = geEnrollment(item.enrollment_code);
                summaryInformation.Add(info);



            }
            return summaryInformation;
        }

        public string geEnrollment(Guid? enrollmentcode)
        {
            if (enrollmentcode == null)
            {
                return "";
            }
            dbcontext = new DBContext();
            return dbcontext.enrollments.Single(x => x.code == enrollmentcode).name.ToString();
        }
        public Information_History_Update_Student getInforUpdate(Guid his_student_code)
        {
            dbcontext = new DBContext();
            Information_History_Update_Student infor = new Information_History_Update_Student();
            history_update_student student = new history_update_student();
            student = dbcontext.history_update_student.Find(his_student_code);
            infor.edit_by_ip = student.edit_by_ip;
            infor.edit_by_user = student.edit_by_user;
            infor.edit_date = student.edit_date;
            infor.action = student.action;
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
        public List<SummaryInformation> getListStudentDuplicateIdentity(string identity)
        {
            dbcontext = new DBContext();
            var liststudent = dbcontext.prestudents.Where(x => x.identity_card == identity).ToList();
            List<SummaryInformation> summaryInformation = new List<SummaryInformation>();
            foreach (var item in liststudent)
            {
                SummaryInformation info = new SummaryInformation();
                info.code = item.code;
                info.name = item.name;
                info.permanent_residence = getPermanent_residence(item.towncode);
                info.sex = item.sex;
                info.totalmark = Math.Round(Convert.ToDouble(item.totalmark) / 6, 2);
                string date = item.date_of_birth.ToString();
                if (date != "" && date != null)
                {
                    string day = date.Split('/')[0];
                    string month = date.Split('/')[1];
                    string year = date.Split('/')[2].Split(' ')[0];

                    info.date_of_birth = day + " / " + month + " / " + year;
                }
                else
                {
                    info.date_of_birth = date;
                }


                info.enrolment = geEnrollment(item.enrollment_code);
                summaryInformation.Add(info);
             


            }
            return summaryInformation;
        }
        public List<Duplicate_identity> getDuplicateIdentity()
        {
            dbcontext = new DBContext();
            var listdb = dbcontext.Database.SqlQuery<Duplicate_identity>("exec dbo.getDuplicateIdentity").ToList();
            return listdb;
        }
        //public bool make_exam_id_for_id(string id_)
        //{
        //    try
        //    {
        //        dbcontext = new DBContext();

        //        var s = (from user in dbcontext.prestudents
        //                 join area_ in dbcontext.towns on user.towncode equals area_.id
        //                 where user.id.Equals(id_)
        //                 select new
        //                 { user.id, area_.region }).First();          

        //        var count = (from user in dbcontext.imformation_user
        //                     join area_ in dbcontext.areas on user.area equals area_.id
        //                     where area_.region.Equals(s.region)
        //                     where user.exam_id != null
        //                     select new
        //                     { user.exam_id}).OrderBy(x=> x.exam_id).First();

        //        int sbd =0;
        //        if (s.region == 0)
        //        {
        //            var ss = (from user in dbcontext.imformation_user
        //                     join area_ in dbcontext.areas on user.area equals area_.id                 
        //                     where area_.region.Equals(1)
        //                     where user.exam_id != null
        //                     select new
        //                     { user.exam_id }).First();
        //            if (ss.exam_id.CompareTo(count.exam_id) > 0)
        //            {
        //                sbd = Int32.Parse(count.exam_id);
        //            }
        //        }

        //        imformation_user user_ = dbcontext.imformation_user.Find(id_);
        //        string myString = (sbd + 1).ToString();
        //        while (myString.Length < 6) myString = "0" + myString;
        //        user_.exam_id = myString;
        //        user_.lock_ = 1;
        //        dbcontext.SaveChanges();

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        public string getPermanent_residence(string towncode)
        {
            dbcontext = new DBContext();

            string Permanent_residence = "";
            if (towncode == null || towncode == "")
            {
                return Permanent_residence;
            }
            string commune = dbcontext.towns.SingleOrDefault(x => x.code == towncode).name;

            string dictrictID = dbcontext.towns.SingleOrDefault(x => x.code == towncode).districtcode;
            string dictrict = dbcontext.districts.SingleOrDefault(x => x.code == dictrictID).name;
            string provincialID = dbcontext.districts.SingleOrDefault(x => x.code == dictrictID).provincecode;
            string provincial = dbcontext.provinces.SingleOrDefault(x => x.code == provincialID).name;

            Permanent_residence = commune + " - " + dictrict + " - " + provincial;
            return Permanent_residence;
        }

       public List<history_update_student> getList_detail_update(Guid code)
        {
            dbcontext = new DBContext();
            var result = dbcontext.history_update_student.Where(x => x.prestudentcode == code).OrderBy(x=>x.edit_date).ToList();
            return result;

        }
        //public List<ExamInformation> getExamInformation()
        //{
        //    List<ExamInformation> summaryInformation = new List<ExamInformation>();
        //    var liststudent = dbcontext.imformation_user.Where(x => x.exam_id != null).OrderBy(x => x.exam_id);
        //    foreach (var item in liststudent)
        //    {
        //        ExamInformation info = new ExamInformation();
        //        info.name = item.name;
        //        info.permanent_residence = getPermanent_residence(item.area);
        //        info.sex = item.sex;
        //        string date = item.date_of_birth.ToString();
        //        if (date != "" && date != null)
        //        {
        //            string day = date.Split('/')[0];
        //            string month = date.Split('/')[1];
        //            string year = date.Split('/')[2].Split(' ')[0];

        //            info.date_of_birth = day + " / " + month + " / " + year;
        //        }
        //        else
        //        {
        //            info.date_of_birth = date;
        //        }


        //        info.admission_group = getAdmission_group(item.admission_group);
        //        info.total_mark = item.total_mark;
        //        info.room_id = item.room_id;
        //        info.exam_id = item.exam_id;
        //        summaryInformation.Add(info);

        //    }
        //    return summaryInformation;
        //}

        //public List<imformation_user> make_exam_identification_number()
        //    {

        //        dbcontext = new DBContext();
        //        limit_candidate limit_candidate = dbcontext.limit_candidate.First();

        //        dbcontext.Database.SqlQuery<string>("update imformation_user set exam_id = null, lock_ = 0, room_id = null");

        //        // mien bac
        //        List<get_imfor_for_make_exam_id> list = dbcontext.Database.SqlQuery<get_imfor_for_make_exam_id>("exec make_exam_id @param1, @param2, 0",
        //            new SqlParameter("param1", limit_candidate.male_north),
        //            new SqlParameter("param2", limit_candidate.female_north)
        //         ).ToList();

        //        foreach (var e in list)
        //        {
        //            //if (e.lock_ == 0)
        //            {
        //                imformation_user us = dbcontext.imformation_user.Find(e.id);
        //                string myString = e.exam_id.ToString();
        //                while (myString.Length < 6) myString = "0" + myString;
        //                us.exam_id = myString;
        //                //us.lock_ = 1;
        //                dbcontext.SaveChanges();
        //            }
        //        }

        //        // mien nam
        //        int begin = list.Count();
        //        list = dbcontext.Database.SqlQuery<get_imfor_for_make_exam_id>("exec make_exam_id @param1, @param2, 1",
        //           new SqlParameter("param1", limit_candidate.male_south),
        //           new SqlParameter("param2", limit_candidate.female_south)
        //        ).ToList();

        //        foreach (var e in list)
        //        {
        //            //if (e.lock_ == 0)
        //            {
        //                imformation_user us = dbcontext.imformation_user.Find(e.id);
        //                string myString = (begin + 10 + e.exam_id).ToString();
        //                while (myString.Length < 6) myString = "0" + myString;
        //                us.exam_id = myString;
        //                //us.lock_ = 1;
        //                dbcontext.SaveChanges();
        //            }
        //        }
        //        // phan phong thi
        //        List<imformation_user> results = dbcontext.Database.SqlQuery<imformation_user>("select * from imformation_user where exam_id is not null order by exam_id").ToList();

        //        List<room> rooms = dbcontext.rooms.ToList();
        //        int room_ = -1;
        //        for (int i = 0; i < results.Count; i++)
        //        {
        //            if (i % 5 == 0) room_++;
        //            imformation_user us = dbcontext.imformation_user.Find(results[i].id);
        //            us.room_id = rooms[room_].name;
        //            //us.lock_ = 1;
        //            dbcontext.SaveChanges();

        //        }
        //        return results;
        //    }
     }
}