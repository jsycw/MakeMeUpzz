using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class MakeupRepository
    {
        MakeMeUpzzDatabaseEntities db = DatabaseSingleton.GetInstance();

        public List<Makeup> getAllMakeups()
        {
            return db.Makeups.ToList();
        }

        public void removeMakeup(int id)
        {
            Makeup mu = db.Makeups.Find(id);
            db.Makeups.Remove(mu);
            db.SaveChanges();
        }

        public List<Makeup> getMakeupsbyBrand(int id)
        {
            return (from x in db.Makeups where x.MakeupBrandID == id select x).ToList();
        }

        public List<Makeup> getMakeupsbyType(int id)
        {
            return (from x in db.Makeups where x.MakeupTypeID == id select x).ToList();
        }

        public void removeMakeupsbyBrand(int id)
        {
            List<Makeup> makeup = getMakeupsbyBrand(id);
            db.Makeups.RemoveRange(makeup);
            db.SaveChanges();
        }

        public void removeMakeupsbyType(int id)
        {
            List<Makeup> makeup = getMakeupsbyType(id);
            db.Makeups.RemoveRange(makeup);
            db.SaveChanges();
        }

        public int getLastID()
        {
            return (from x in db.Makeups select x.MakeupID).ToList().LastOrDefault();
        }

        public int generateID()
        {
            if (db.Makeups.Count() == 0)
            {
                return 1;
            }
            else
            {
                int lastId = getLastID();
                return ++lastId;
            }
        }

        public void addMakeup(String name, int price, int weight, int typeID, int brandID)
        {
            int id = generateID();
            Makeup makeup = MakeupFactory.Create(id, name, price, weight, typeID, brandID);
            db.Makeups.Add(makeup);
            db.SaveChanges();
        }

        public Makeup getMakeupByID(int id)
        {
            return (from x in db.Makeups where x.MakeupID == id select x).ToList().FirstOrDefault();
        }

        public void updateMakeup(int id, String name, int price, int weight, int typeID, int brandID)
        {
            Makeup makeup = getMakeupByID(id);
            makeup.MakeupName = name;
            makeup.MakeupPrice = price;
            makeup.MakeupWeight = weight;
            makeup.MakeupTypeID = typeID;
            makeup.MakeupBrandID = brandID;
            db.SaveChanges();
        }
    }
}