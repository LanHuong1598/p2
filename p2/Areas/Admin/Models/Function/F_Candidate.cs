using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2.Models.Entities;
using p2.Areas.Admin.Models.Handler;
namespace p2.Areas.Admin.Models.Function
{
    public class F_Candidate
    {
        DBContext dbcontext = new DBContext();
        public List<SummaryInformation> getInfor()
        {
            List<SummaryInformation> summaryInformation = new List<SummaryInformation>();
            var liststudent = dbcontext.imformation_user.ToList();
            foreach(var item in liststudent)
            {
                SummaryInformation info = new SummaryInformation();
                info.name = item.name;
                info.permanent_residence = getPermanent_residence(item.area);
                info.sex = item.sex;
                string date = item.date_of_birth.ToString();
                if(date !="" && date!=null)
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
                
                
                info.admission_group = getAdmission_group(item.admission_group);
                summaryInformation.Add(info);
             
                

            }
            return summaryInformation;
        }

        public string getAdmission_group(int? admission_id)
        {
            if(admission_id == null || admission_id == 0)
            {
                return "";
            }
            dbcontext = new DBContext();
            return dbcontext.admission_group.Single(x => x.id == admission_id).name.ToString();
        }
        public string getPermanent_residence(string areaID)
        {
            dbcontext = new DBContext();
            
            string Permanent_residence = "";
            if(areaID == null || areaID=="")
            {
                return Permanent_residence;
            }
            string commune = dbcontext.areas.SingleOrDefault(x => x.id == areaID).name;

            string dictrictID = dbcontext.areas.SingleOrDefault(x => x.id == areaID).parent;
            string dictrict = dbcontext.areas.SingleOrDefault(x => x.id == dictrictID).name;
            string provincialID = dbcontext.areas.SingleOrDefault(x => x.id == dictrictID).parent;
            string provincial = dbcontext.areas.SingleOrDefault(x => x.id == provincialID).name;

            Permanent_residence = commune + " - " + dictrict + " - " + provincial;
            return Permanent_residence;
        }
    }
}