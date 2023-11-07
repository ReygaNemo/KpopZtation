using KpopZtationNew.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationNew.Repository
{
    public class CartRepository
    {
        public static List<Cart> GetCart()
        {
            DBE db = new DBE();
            List<Cart> carts = (from cart in db.Carts select cart).ToList();
            return carts;
        }
        public static List<Cart> GetCartByCustomerId(int custid)
        {
            DBE db = new DBE();
            List<Cart> carts = (from cart in db.Carts
                                where cart.CustomerID == custid
                                select cart).ToList();
            return carts;
        }
        public static int AddCart(int albumid, int custid, int qtys)
        {
            DBE db = new DBE();

            Cart c = CartFactory.createCart(albumid, custid, qtys);

            db.Carts.Add(c);
            db.SaveChanges();

            return 0;
        }
        public static Boolean DeleteCart(int custId, int albumId)
        {
            DBE db = new DBE();
            
            var cartItem = (from cart in db.Carts
                                where cart.AlbumID == albumId && cart.CustomerID == custId
                                select cart).FirstOrDefault();
                db.Carts.Remove(cartItem);
                db.SaveChanges();
            return true;
        }
        public static Boolean DeleteCartByCustomer(int custId)
        {
            DBE db = new DBE();
            var cartItem = (from cart in db.Carts
                            where cart.CustomerID == custId
                            select cart).FirstOrDefault();
            db.Carts.Remove(cartItem);
            db.SaveChanges();
            return true;
        }

    }
}