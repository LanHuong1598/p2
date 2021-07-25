using p2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2.Models.Function
{
    public class F_region_mark
    {
        DBContext dbcontext;
        public List<regionmark> getRegionMarks()
        {
            dbcontext = new DBContext();
            return dbcontext.regionmarks.ToList();
        }
        public regionmark getRegionByCode(Guid? code)
        {
            dbcontext = new DBContext();
            return dbcontext.regionmarks.Find(code);
        }
    }
}