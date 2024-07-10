using MakeMeUpzz.Models;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handlers
{
    public class MakeupHandler
    {
        MakeupRepository makeupRepo = new MakeupRepository();
        TransactionRepository tranRepo = new TransactionRepository();
        CartRepository cartRepo = new CartRepository();
        public List<Makeup> GetAllMakeup()
        {
            return makeupRepo.getAllMakeups();
        }

        public void removeMakeup(int makeupId)
        {
            tranRepo.RemoveTransactionDetailsByMakeupId(makeupId);
            cartRepo.RemoveCartsByMakeupId(makeupId);
            makeupRepo.removeMakeup(makeupId);
        }

        public void addMakeup(String name, int price, int weight, int typeID, int brandID)
        {
            makeupRepo.addMakeup(name, price, weight, typeID, brandID);
        }

        public Makeup getMakeupById(int id)
        {
            return makeupRepo.getMakeupByID(id);
        }

        public void updateMakeup(int id, String name, int price, int weight, int typeID, int brandID)
        {
            makeupRepo.updateMakeup(id, name, price, weight, typeID, brandID);
        }
    }
}