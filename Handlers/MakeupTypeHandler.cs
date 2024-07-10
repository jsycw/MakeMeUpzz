using MakeMeUpzz.Models;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handlers
{
    public class MakeupTypeHandler
    {
        MakeupTypeRepository typeRepo = new MakeupTypeRepository();

        public void DeleteMakeupType(int id)
        {
            MakeupType type = typeRepo.getMakeupTypebyID(id);

            //kalo misalnya makeuptype yang dicari ga ada
            if (type == null)
            {
                //Debug.WriteLine("masuk di type null");
                return;
            }

            if (type.Makeups.Count > 0)
            {
                MakeupHandler makeupHandler = new MakeupHandler();
                MakeupRepository makeupRepo = new MakeupRepository();

                List<Makeup> makeups = makeupRepo.getMakeupsbyType(id);
                foreach(Makeup makeup in makeups)
                {
                    makeupHandler.removeMakeup(makeup.MakeupID);
                }
            }

            typeRepo.removeMakeupTypes(id);
        }


        public List<MakeupType> GetMakeupTypes()
        {
            return typeRepo.getAllMakeupTypes();
        }

        public void addMakeupType(String name)
        {
            typeRepo.addMakeupType(name);
        }

        public MakeupType getMakeupTypeById(int id)
        {
            return typeRepo.getMakeupTypebyID(id);
        }

        public void updateMakeupType(int id, String name)
        {
            typeRepo.updateMakeupType(id, name);
        }
    }
}