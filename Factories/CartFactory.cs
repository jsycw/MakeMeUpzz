using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factories
{
    public class CartFactory
    {
        public static Cart Create(int id, int userId, int makeupId, int quantity)
        {
            Cart cart = new Cart();
            cart.CartID = id;
            cart.UserID = userId;
            cart.MakeupID = makeupId;
            cart.Quantity = quantity;
            return cart;
        }
    }
}