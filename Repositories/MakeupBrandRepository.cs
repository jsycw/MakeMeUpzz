using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class MakeupBrandRepository
    {
        MakeMeUpzzDatabaseEntities db = DatabaseSingleton.GetInstance();
        public void removeMakeupBrands(int id)
        {
            MakeupBrand brand = db.MakeupBrands.Find(id);
            db.MakeupBrands.Remove(brand);
            db.SaveChanges();
        }

        public MakeupBrand getMakeupBrandbyId(int id)
        {
            return (from x in db.MakeupBrands where x.MakeupBrandID == id select x).FirstOrDefault();
        }

        public List<MakeupBrand> GetMakeupBrands()
        {
            return db.MakeupBrands.ToList();
        }

        public List<MakeupBrand> makeupBrandsDesc()
        {
            return db.MakeupBrands.OrderByDescending(rating => rating.MakeupBrandRating).ToList();
        }

        public int getLastID()
        {
            return (from x in db.MakeupBrands select x.MakeupBrandID).ToList().LastOrDefault();
        }

        public int generateID()
        {
            if (db.MakeupBrands.Count() == 0)
            {
                return 1;
            }
            else
            {
                int lastID = getLastID();
                return ++lastID;
            }
        }
        public void addMakeupBrand(String name, int rating)
        {
            int id = generateID();
            MakeupBrand makeUpBrand = MakeupBrandFactory.Create(id, name, rating);
            db.MakeupBrands.Add(makeUpBrand);
            db.SaveChanges();
        }

        public void updateMakeupBrand(int id, String name, int rating)
        {
            MakeupBrand makeupbr = getMakeupBrandbyId(id);
            makeupbr.MakeupBrandName = name;
            makeupbr.MakeupBrandRating = rating;
            db.SaveChanges();
        }
    }
}