using KpopZtationNew.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationNew.Repository
{
    public class TransactionRepository
    {
        public static void AddTransaction(DateTime transdate, int custid, int albumid, int qtys)
        {
            DBE db = new DBE();

            TransactionHeader ch = TransactionHeadFactory.createTransactionHeader(transdate, custid);
            TransactionDetail cd = TransactionDetailFactory.createTransactionDetail(ch.TransactionID, albumid, qtys);
            db.TransactionHeaders.Add(ch);
            db.TransactionDetails.Add(cd);
            db.SaveChanges();
        }
        public static List<TransactionHeader> GetTransHeadByCustomerId(int custid)
        {
            DBE db = new DBE();
            List<TransactionHeader> transH = (from tranH in db.TransactionHeaders
                                where tranH.CustomerID == custid
                                select tranH).ToList();
            return transH;
        }
        public static List<TransactionDetail> GetTransDetailByCustomerId(int custid)
        {
            DBE db = new DBE();
            List<TransactionDetail> transD = (from tranH in db.TransactionHeaders
                                             where tranH.CustomerID == custid
                                             from tranD in tranH.TransactionDetails
                                             select tranD).ToList();
            return transD;
        }

    }
}