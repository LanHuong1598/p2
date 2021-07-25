using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2.Models.Entities;
namespace p2.Models.Function
{
    public class F_record
    {
        DBContext dbcontext;
        public record getRecodebyCode(Guid? code)
        {
            dbcontext = new DBContext();
            record re = new record();
            re = dbcontext.records.Find(code);
            return re;
        }
    }
}