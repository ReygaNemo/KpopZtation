using KpopZtationNew.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationNew.Controller
{
    public class TransactionController
    {
        public static void AddTransaction(DateTime transdate, int custid,  int albumid, int qtys)
        {
            TransactionHandler.AddTransaction( transdate,  custid,   albumid,  qtys);
        }
        public static List<TransactionHeader> GetTransHeadByCustomerId(int custid)
        {
            return TransactionHandler.GetTransHeadByCustomerId(custid);
        }
        public static List<TransactionDetail> GetTransDetailByCustomerId(int custid)
        {
            return TransactionHandler.GetTransDetailByCustomerId(custid);
        }
    }
}