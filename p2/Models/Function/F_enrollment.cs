using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2.Models.Entities;
namespace p2.Models.Function
{
    public class F_enrollment
    {
        DBContext dbcontext;
        public List<enrollment> Getenrollment()
        {
            using (dbcontext = new DBContext())
            {
                return dbcontext.enrollments.ToList();
            }
                

        }
        public string getNameEnrollment(Guid? code)
        {
            dbcontext = new DBContext();
           
            return dbcontext.enrollments.Find(code).name;
          
        }
        public enrollment getEnrollmentbyCode(Guid? code)
        {
            dbcontext = new DBContext();
            return dbcontext.enrollments.Find(code);
        }
    }
    
}