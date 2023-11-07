using KpopZtationNew.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationNew.Handler
{
    public class TransactionHandler
    {
        public static void AddTransaction(DateTime transdate, int custid, int albumid, int qtys)
        {
            TransactionRepository.AddTransaction(transdate, custid, albumid, qtys);
        }
        public static List<TransactionHeader> GetTransHeadByCustomerId(int custid)
        {
            return TransactionRepository.GetTransHeadByCustomerId(custid);
        }
        public static List<TransactionDetail> GetTransDetailByCustomerId(int custid)
        {
            return TransactionRepository.GetTransDetailByCustomerId(custid);
        }
    }
}