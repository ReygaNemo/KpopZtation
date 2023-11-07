using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationNew.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail createTransactionDetail(int transid, int albumid, int qtys)
        {
            TransactionDetail c = new TransactionDetail();
            c.TransactionID = transid;
            c.AlbumID = albumid;
            c.Qty = qtys;
            return c;
        }
    }
}