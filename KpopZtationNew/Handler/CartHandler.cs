using KpopZtationNew.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationNew.Handler
{
    public class CartHandler
    {
        public static List<Cart> GetCarts()
        {
            return CartRepository.GetCart();
        }
        public static List<Cart> GetCartByCustomerId(int custid)
        {
            return CartRepository.GetCartByCustomerId(custid);
        }
        public static int AddCart(int albumid, int custid, int qtys)
        {
            return CartRepository.AddCart( albumid, custid, qtys);
        }
        public static Boolean DeleteCart(int custId, int albumid)
        {
             return CartRepository.DeleteCart( custId,  albumid);
        }
        public static Boolean DeleteCartByCustomer(int custId)
        {
            return CartRepository.DeleteCartByCustomer(custId);
        }
    }
}