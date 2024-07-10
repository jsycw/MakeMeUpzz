using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class MakeupTypeRepository
    {
        MakeMeUpzzDatabaseEntities db = DatabaseSingleton.GetInstance();
        public List<MakeupType> getAllMakeupTypes()
        {
            return db.MakeupTypes.ToList();
        }

        public MakeupType getMakeupTypebyID(int id)
        {
            return (from x in db.MakeupTypes where x.MakeupTypeID == id select x).FirstOrDefault();
        }

        public void removeMakeupTypes(int id)
        {
            MakeupType type = db.MakeupTypes.Find(id);
            db.MakeupTypes.Remove(type);
            db.SaveChanges();
        }

        public int getLastId()
        {
            return (from x in db.MakeupTypes select x.MakeupTypeID).ToList().LastOrDefault();
        }

        public int generateID()
        {
            if (db.MakeupTypes.Count() == 0)
            {
                return 1;
            }
            else
            {
                int lastId = getLastId();
                return ++lastId;
            }
        }
        public void addMakeupType(String name)
        {
            int id = generateID();
            MakeupType makeUpType = MakeupTypeFactory.Create(id, name);
            db.MakeupTypes.Add(makeUpType);
            db.SaveChanges();
        }

        public void updateMakeupType(int id, String name)
        {
            MakeupType makeupType = getMakeupTypebyID(id);
            makeupType.MakeupTypeName = name;
            db.SaveChanges();
        }
    }
}