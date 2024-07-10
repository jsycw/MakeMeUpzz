using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factories
{
    public class MakeupFactory
    {
        public static Makeup Create(int id, String name, int price, int weight, int typeId, int brandId)
        {
            Makeup makeup = new Makeup();
            makeup.MakeupID = id;
            makeup.MakeupName = name;
            makeup.MakeupPrice = price;
            makeup.MakeupWeight = weight;
            makeup.MakeupTypeID = typeId;
            makeup.MakeupBrandID = brandId;
            return makeup;
        }
    }
}