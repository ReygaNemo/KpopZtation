using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationNew.Factory
{
    public class CustomerFactory
    {
        public static Customer createCustomer(String name, String email, String gender, String address, String password)
        {
            Customer c = new Customer();

            c.CustomerName = name;
            c.CustomerEmail = email;
            c.CustomerGender = gender;
            c.CustomerAddress = address;
            c.CustomerPassword = password;
            c.CustomerRole = "Customer";

            return c;
        }
    }
}