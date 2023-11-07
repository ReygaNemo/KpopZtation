using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtationNew.Handler;

namespace KpopZtationNew.Controller
{
    public class CustomerController
    {
        public static List<Customer> GetCustomers()
        {
            return CustomerHandler.GetCustomers();
        }

        public static int AddCustomer(String name, String email, String gender, String address, String password)
        {
            int emailflag = 0;
            int passwordflag = 0;

            DBE db = new DBE();
            List<Customer> customers = (from c in db.Customers select c).ToList();

            if(customers.Count > 0)
            {
                foreach (Customer customer in customers)
                {
                    if (customer.CustomerEmail == email)
                    {
                        emailflag = 0;
                        break;
                    }
                    else
                    {
                        emailflag = 1;
                    }
                }
            }
            else
            {
                emailflag = 1;
            }
            bool isAlphanumeric = System.Text.RegularExpressions.Regex.IsMatch(password, "^[a-zA-Z0-9]*$");

            if (isAlphanumeric) passwordflag = 1;

            if (name.Equals("") || name.Length < 5 || name.Length > 50) return 1;
            else if (email.Equals("") || emailflag == 0) return 2;
            else if (gender.Equals("")) return 3;
            else if (address.Equals("") || !address.EndsWith("Street")) return 4;
            else if (password.Equals("") || passwordflag == 0) return 5;

            return CustomerHandler.AddCustomer(name, email, gender, address, password);
        }

        public static Boolean Login(String email, String password)
        {
            if (email.Equals("")) return false;
            else if (password.Equals("")) return false;

            return CustomerHandler.Login(email, password);
        }
    }
}