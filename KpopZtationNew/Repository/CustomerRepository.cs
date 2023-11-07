using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtationNew.Factory;

namespace KpopZtationNew.Repository
{
    public class CustomerRepository
    {
        public static List<Customer> GetCustomers()
        {
            DBE db = new DBE();
            List<Customer> customers = (from c in db.Customers select c).ToList();
            return customers;
        }
        public static int AddCustomer(String name, String email, String gender, String address, String password)
        {
            DBE db = new DBE();

            Customer c = CustomerFactory.createCustomer(name, email, gender, address, password);

            db.Customers.Add(c);
            db.SaveChanges();

            return 0;
        }
        public static Boolean Login(String email, String password)
        {
            using (var context = new DBE())
            {
                var customer = context.Customers.FirstOrDefault(c => c.CustomerEmail == email && c.CustomerPassword == password);

                if (customer != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}