using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factories
{
    public class MakeupBrandFactory
    {
        public static MakeupBrand Create(int id, String name, int rating)
        {
            MakeupBrand makeupBrand = new MakeupBrand();
            makeupBrand.MakeupBrandID = id;
            makeupBrand.MakeupBrandName = name;
            makeupBrand.MakeupBrandRating = rating;
            return makeupBrand;
        }
    }
}