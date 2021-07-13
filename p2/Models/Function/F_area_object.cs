using p2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2.Models.Function
{
    public class F_area_object
    {
        DBContext dbcontext;
        public List<area_object> getAreaObjects()
        {
            dbcontext = new DBContext();
            return dbcontext.area_object.ToList();
        }
    }
}