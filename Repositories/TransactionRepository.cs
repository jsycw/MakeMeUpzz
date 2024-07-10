using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class TransactionRepository
    {
        MakeMeUpzzDatabaseEntities db = DatabaseSingleton.GetInstance();

        public List<TransactionHeader> GetAllTransaction()
        {
            return (from t in db.TransactionHeaders select t).ToList();
        }

        public List<TransactionHeader> GetUserTransaction(User user)
        {
            return (from t in db.TransactionHeaders where user.UserID == t.UserID select t).ToList();
        }

        public TransactionHeader GetTransactionById(int id)
        {
            return (from t in db.TransactionHeaders where t.TransactionID == id select t).FirstOrDefault();
        }

        public List<TransactionHeader> GetAllUnhandledTransaction()
        {
            return (from t in db.TransactionHeaders where t.Status == "Unhandled" select t).ToList();
        }

        public void UpdateTransactionStatusById(int id)
        {
            TransactionHeader tranHeader = db.TransactionHeaders.Find(id);
            tranHeader.Status = "Handled";
            db.SaveChanges();
        }

        public int getLastID()
        {
            return (from x in db.TransactionHeaders select x.TransactionID).ToList().LastOrDefault();
        }

        public int generateID()
        {
            
            if (db.TransactionHeaders.Count() == 0)
            {
                return 1;
            }
            else
            {
                int lastID = getLastID();
                return ++lastID;
            }
        }

        public void Checkout(int userId, List<Cart> cartItems)
        {

            TransactionHeader transactionHeader = TransactionHeaderFactory.Create(generateID(), userId, DateTime.Now, "Unhandled");
            db.TransactionHeaders.Add(transactionHeader);
            db.SaveChanges();

            foreach (var c in cartItems)
            {
                TransactionDetail transactionDetail = TransactionDetailFactory.Create(transactionHeader.TransactionID, c.MakeupID, c.Quantity);
                db.TransactionDetails.Add(transactionDetail);
                db.SaveChanges();
            }
        }

        public void RemoveTransactionDetailsByMakeupId(int makeupId)
        {
            List<TransactionDetail> tranDetail = (from tran in db.TransactionDetails where tran.MakeupID == makeupId select tran).ToList();
            db.TransactionDetails.RemoveRange(tranDetail);
            db.SaveChanges();
        }
    }
}