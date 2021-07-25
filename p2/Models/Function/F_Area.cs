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
        
        public List<province> getProvincials()
        {
            dbcontext = new DBContext();
            return dbcontext.provinces.ToList();
        }

        public List<district> getDistricts()
        {
            dbcontext = new DBContext();
            
            return dbcontext.districts.ToList();
        }
        public List<district> getDistrictsByProvincial(string provincialcode)
        {
            dbcontext = new DBContext();
            List<district> Districts = new List<district>();
            Districts = dbcontext.districts.Where(x => x.provincecode == provincialcode).ToList();
            return Districts;
        }
        public string getDistrictCodeByTown(string towncode)
        {
            dbcontext = new DBContext();
            town tow = dbcontext.towns.Find(towncode);
            string id = tow.districtcode;     
            return id;
        }

        
        public string getProvincialCodeByDistrict(string districtcode)
        {
            dbcontext = new DBContext();
            string id = "";
            district district = dbcontext.districts.Find(districtcode);
            id = district.provincecode;
            return id;
        }

        public List<town> getTowns()
        {
            dbcontext = new DBContext();

            return dbcontext.towns.ToList();
        }

        public town getTownbycode(string code)
        {
            dbcontext = new DBContext();
            return dbcontext.towns.Find(code);
        }
        public district getDistrictbycode(string code)
        {
            dbcontext = new DBContext();
            return dbcontext.districts.Find(code);
        }
        public province getProvincebycode(string code)
        {
            dbcontext = new DBContext();
            return dbcontext.provinces.Find(code);
        }

        public List<town> getTownsByDistrict(string districtcode)
        {
            dbcontext = new DBContext();
            List<town> towns = new List<town>();
            towns = dbcontext.towns.Where(x => x.districtcode == districtcode).ToList();
            return towns;
        }
    }
}