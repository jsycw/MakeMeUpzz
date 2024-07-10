using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factories
{
    public class MakeupTypeFactory
    {
        public static MakeupType Create(int id, String name)
        {
            MakeupType makeupType = new MakeupType();
            makeupType.MakeupTypeID = id;
            makeupType.MakeupTypeName = name;
            return makeupType;
        }
    }
}