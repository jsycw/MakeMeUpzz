using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class CartController
    {
        CartHandler cartHandler = new CartHandler();

        public List<Cart> GetCartItemsByUserId(int userId)
        {
            return cartHandler.GetCartItemsByUserId(userId);
        }

        public void AddToCart(int userId, int makeupId, int quantity)
        {
            cartHandler.AddToCart(userId, makeupId, quantity);
        }
        public void ClearCart(int userId)
        {
            cartHandler.ClearCart(userId);
        }
    }
}