using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationNew.Factory
{
    public class TransactionHeadFactory
    {
        public static TransactionHeader createTransactionHeader(DateTime transdate, int custid)
        {
            TransactionHeader c = new TransactionHeader();
            c.TransactionDate = transdate;
            c.CustomerID = custid;
            return c;
        }
    }
}