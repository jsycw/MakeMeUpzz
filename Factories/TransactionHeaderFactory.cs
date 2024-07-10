using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factories
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader Create(int id, int userId, DateTime date, String status)
        {
            TransactionHeader transactionHeader = new TransactionHeader();
            transactionHeader.TransactionID = id;
            transactionHeader.UserID = userId;
            transactionHeader.TransactionDate = date;
            transactionHeader.Status = status;
            return transactionHeader;
        }
    }
}