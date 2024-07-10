using MakeMeUpzz.Models;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Handlers;

namespace MakeMeUpzz.Handlers
{
    public class TransactionsHandler
    {
        TransactionRepository tranRepo = new TransactionRepository();
        public List<TransactionHeader> GetAllTransaction()
        {
            return tranRepo.GetAllTransaction();
        }
        public List<TransactionHeader> GetUserTransaction(User currUser)
        {
            return tranRepo.GetUserTransaction(currUser);
        }

        public TransactionHeader GetTransactionById(int id)
        {
            return tranRepo.GetTransactionById(id);
        }

        public List<TransactionHeader> GetAllUnhandledTransaction()
        {
            return tranRepo.GetAllUnhandledTransaction();
        }

        public void UpdateTransactionStatusById(int id)
        {
            tranRepo.UpdateTransactionStatusById(id);
        }

        public void Checkout(int userId, List<Cart> cartItems)
        {
            tranRepo.Checkout(userId, cartItems);
        }
    }
}