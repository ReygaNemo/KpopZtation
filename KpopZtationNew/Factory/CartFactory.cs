using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationNew.Factory
{
    public class CartFactory
    {
        public static Cart createCart(int albumid, int custid, int qtys )
        {
            Cart a = new Cart();
            a.AlbumID = albumid;
            a.CustomerID = custid;
            a.Qty = qtys;

            return a;
        }
    }
}