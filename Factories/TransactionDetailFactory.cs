using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factories
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail Create(int transactionId, int makeupId, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail();
            transactionDetail.TransactionID = transactionId;
            transactionDetail.MakeupID = makeupId;
            transactionDetail.Quantity = quantity;
            return transactionDetail;
        }
    }
}