using p2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2.Models.Function
{
    
    public class F_Priority_object
    {
        DBContext dbcontext;
        public List<priority_object> getPriority_Objects()
        {
            dbcontext = new DBContext();
            return dbcontext.priority_object.ToList();
        }
    }
}