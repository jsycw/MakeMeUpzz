using MakeMeUpzz.Models;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handlers
{
    public class MakeupBrandHandler
    {
        MakeupBrandRepository brandRepo = new MakeupBrandRepository();

        public void DeleteMakeupBrand(int id)
        {
            MakeupBrand brand = brandRepo.getMakeupBrandbyId(id);

            //kalo brand nya ga ketemu
            if (brand == null)
            {
                return;
            }

            if (brand.Makeups.Count > 0)
            {
                MakeupHandler makeupHandler = new MakeupHandler();
                MakeupRepository makeupRepo = new MakeupRepository();

                List<Makeup> makeups = makeupRepo.getMakeupsbyBrand(id);
                foreach (Makeup makeup in makeups)
                {
                    makeupHandler.removeMakeup(makeup.MakeupID);
                }
            }

            brandRepo.removeMakeupBrands(id);
        }

        //ngambil semua make up brand tapi di sort descending dari rating
        public List<MakeupBrand> getMakeupBrandsDesc()
        {
            return brandRepo.makeupBrandsDesc();
        }

        public void addMakeupBrand(String name, int rating)
        {
            brandRepo.addMakeupBrand(name, rating);
        }

        public MakeupBrand getMakeupBrandByID(int id)
        {
            return brandRepo.getMakeupBrandbyId(id);
        }

        public void updateMakeupBrand(int id, String name, int rating)
        {
            brandRepo.updateMakeupBrand(id, name, rating);
        }
    }
}