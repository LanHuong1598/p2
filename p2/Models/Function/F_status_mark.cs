using p2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2.Models.Function
{
    
    public class F_status_mark
    {
        DBContext dbcontext;
        public List<statusmark> getStatus_marks()
        {
            dbcontext = new DBContext();
            return dbcontext.statusmarks.ToList();
        }

        public statusmark getStatusByCode(Guid? code)
        {
            dbcontext = new DBContext();
            return dbcontext.statusmarks.Find(code);
        }
    }
}