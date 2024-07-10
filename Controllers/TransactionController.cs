using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class TransactionController
    {
        TransactionsHandler tranHandler = new TransactionsHandler();
        public List<TransactionHeader> GetAllTransaction()
        {
            return tranHandler.GetAllTransaction();
        }

        public List<TransactionHeader> GetUserTransaction(User currUser)
        {
            return tranHandler.GetUserTransaction(currUser);
        }

        public TransactionHeader GetTransactionById(int id)
        {
            return tranHandler.GetTransactionById(id);
        }

        public List<TransactionHeader> GetAllUnhandledTransaction()
        {
            return tranHandler.GetAllUnhandledTransaction();
        }

        public void UpdateTransactionStatusById(int id)
        {
            tranHandler.UpdateTransactionStatusById(id);
        }

        public void Checkout(int userId, List<Cart> cartItems)
        {
            tranHandler.Checkout(userId, cartItems);
        }
    }
}