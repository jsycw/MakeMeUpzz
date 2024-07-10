using MakeMeUpzz.Models;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handlers
{
    public class CartHandler
    {
        CartRepository cartRepo = new CartRepository();

        public List<Cart> GetCartItemsByUserId(int userId)
        {
            return cartRepo.GetCartItemsByUserId(userId);
        }

        public void AddToCart(int userId, int makeupId, int quantity)
        {
            cartRepo.AddToCart(userId, makeupId, quantity);
        }

        public void ClearCart(int userId)
        {
            cartRepo.ClearCart(userId);
        }
    }
}