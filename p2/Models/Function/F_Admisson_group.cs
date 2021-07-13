using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2.Models.Entities;
namespace p2.Models.Function
{
    public class F_Admisson_group
    {
        DBContext dbcontext;
        public List<admission_group> GetAdmission_Groups()
        {
            using (dbcontext = new DBContext())
            {
                return dbcontext.admission_group.ToList();
            }
                

        }
    }
    
}