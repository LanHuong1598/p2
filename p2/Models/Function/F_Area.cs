using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2.Models.Entities;
namespace p2.Models.Function
{
    public class F_Area
    {
        DBContext dbcontext;
        public List<area> getAreas()
        {
            dbcontext = new DBContext();
            return dbcontext.areas.ToList();
        }
        public List<area> getProvincials()
        {
            dbcontext = new DBContext();
            List<area> provincials = new List<area>();
            provincials = dbcontext.areas.Where(x => x.level == 1).ToList();
            return provincials;
        }

        public List<area> getDistricts()
        {
            dbcontext = new DBContext();
            List<area> Districts = new List<area>();
            Districts = dbcontext.areas.Where(x => x.level == 2).ToList();
            return Districts;
        }
        public List<area> getDistrictsByProvincial(string provincialID)
        {
            dbcontext = new DBContext();
            List<area> Districts = new List<area>();
            Districts = dbcontext.areas.Where(x => x.parent == provincialID).ToList();
            return Districts;
        }
        public List<area> getCommunes()
        {
            dbcontext = new DBContext();
            List<area> Communes = new List<area>();
            Communes = dbcontext.areas.Where(x => x.level == 3).ToList();
            return Communes;
        }
        public List<area> getCommunesByDistrict(string districtID)
        {
            dbcontext = new DBContext();
            List<area> Communes = new List<area>();
            Communes = dbcontext.areas.Where(x => x.parent == districtID ).ToList();
            return Communes;
        }
    }
}