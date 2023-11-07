using KpopZtationNew.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationNew.Controller
{
    public class CartController
    {
        public static List<Cart> GetCarts()
        {
            return CartHandler.GetCarts();
        }
        public static List<Cart> GetCartByCustomerId(int custid)
        {
            return CartHandler.GetCartByCustomerId(custid);
        }
        public static void AddCart(int albumid, int custid, int qtys)
        {
            CartHandler.AddCart( albumid,  custid,  qtys);
        }
        public static Boolean DeleteCart(int custId, int albumid)
        {
           return CartHandler.DeleteCart(custId, albumid);
        }
        public static Boolean DeleteCartByCustomer(int custId)
        {
            return CartHandler.DeleteCartByCustomer(custId);
        }
    }
}