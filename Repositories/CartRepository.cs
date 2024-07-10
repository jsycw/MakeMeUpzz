using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class CartRepository
    {
        MakeMeUpzzDatabaseEntities db = DatabaseSingleton.GetInstance();

        public List<Cart> GetCartItemsByUserId(int userId)
        {
            return db.Carts.Where(c => c.UserID == userId).ToList();
        }

        public int getLastID()
        {
            return (from x in db.Carts select x.CartID).ToList().LastOrDefault();
        }

        public int generateId()
        {
            if (db.Carts.Count() == 0)
            {
                return 1;
            }
            else
            {
                int lastID = getLastID();
                return ++lastID;
            }
        }

        public void AddToCart(int userId, int makeupId, int quantity)
        {
            try
            {
                Cart cartItem = (from x in db.Carts where x.UserID ==  userId &&  x.MakeupID == makeupId select x).FirstOrDefault();

                if (cartItem != null)
                {
                    cartItem.Quantity += quantity;
                }
                else
                {
                    cartItem = CartFactory.Create(generateId(), userId, makeupId, quantity);
                    db.Carts.Add(cartItem);
                }

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error adding to cart", ex);
            }
        }

        public void ClearCart(int userId)
        {
            List<Cart> cartItems = db.Carts.Where(c => c.UserID == userId).ToList();
            db.Carts.RemoveRange(cartItems);
            db.SaveChanges();
        }

        public void RemoveCartsByMakeupId(int makeupId)
        {
            List<Cart> cartItems = (from cart in db.Carts where cart.MakeupID==makeupId select cart).ToList();
            db.Carts.RemoveRange(cartItems);
            db.SaveChanges();
        }
    }
}