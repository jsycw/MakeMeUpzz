using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class MakeupController
    {
        MakeupHandler makeupHandler = new MakeupHandler();
        MakeupBrandHandler makeupBrandHandler = new MakeupBrandHandler();
        MakeupTypeHandler makeupTypeHandler = new MakeupTypeHandler();
        public bool validateName(String name)
        {
            if (name.Length >= 1 && name.Length <= 99)
            {
                return true;
            }
            else return false;
        }
        public bool validateRate(int rating)
        {
            if (rating >= 0 && rating <= 100)
            {
                return true;
            }
            return false;
        }

        public bool validate(String name, String price, String weight, String typeId, String brandId)
        {
            if(name != null && price != null && weight != null && typeId != null && brandId != null)
            {
                int p = Convert.ToInt32(price);
                int w = Convert.ToInt32(weight);

                if (validateName(name) && p >= 1 && w <= 1500)
                {
                    return true;
                }
                else return false;
            }

            else return false;
        }

        public List<Makeup> GetAllMakeup()
        {
            return makeupHandler.GetAllMakeup();
        }

        //tammpilin semua makeup brand dengan rating sort secara descending
        public List<MakeupBrand> GetAllBrandsDesc()
        {
            return makeupBrandHandler.getMakeupBrandsDesc();
        }

        public List<MakeupType> GetAllTypes()
        {
            return makeupTypeHandler.GetMakeupTypes();
        }

        public void removeMakeups(int id)
        {
            makeupHandler.removeMakeup(id);
        }

        public void removeMakeupType(int id)
        {
            makeupTypeHandler.DeleteMakeupType(id);
        }

        public void removeMakeupBrand(int id)
        {
            makeupBrandHandler.DeleteMakeupBrand(id);
        }

        //makeup doangg
        public void addMakeup(String name, int price, int weight, int typeID, int brandID)
        {
            makeupHandler.addMakeup(name, price, weight, typeID, brandID);
        }

        public Makeup getMakeupById (int id)
        {
            return makeupHandler.getMakeupById(id);
        }

        public void updateMakeup(int id, String name, int price, int weight, int typeID, int brandID)
        {
            makeupHandler.updateMakeup(id, name, price, weight, typeID, brandID);
        }


        //make up type
        public void addMakeupType(String name)
        {
            makeupTypeHandler.addMakeupType(name);
        }
        public MakeupType GetMakeupTypeByID(int id)
        {
            return makeupTypeHandler.getMakeupTypeById(id);
        }
        public void updateMakeupType(int id, String name)
        {
            makeupTypeHandler.updateMakeupType(id, name);
        }



        //makeup brand
        public void addMakeupBrand(String name, int rating)
        {
            makeupBrandHandler.addMakeupBrand(name, rating);
        }

        public MakeupBrand getMakeupBrandById(int id)
        {
            return makeupBrandHandler.getMakeupBrandByID(id);
        }

        public void updateMakeupBrand(int id, String name, int rating)
        {
            makeupBrandHandler.updateMakeupBrand(id, name, rating);
        }
    }
}