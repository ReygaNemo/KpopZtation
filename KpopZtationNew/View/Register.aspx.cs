using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtationNew.Controller;

namespace KpopZtationNew.View
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register(object sender, EventArgs e)
        {
            int check = CustomerController.AddCustomer(nameField.Text, emailField.Text, genderField.Text, addressField.Text, passwordField.Text);

            if (check == 1)
            {
                errorMsg.Text = "Name length must be between 5 - 50 characters!";
                return;
            }
            else if (check == 2)
            {
                errorMsg.Text = "Email must be in a correct format!";
                return;
            }
            else if (check == 3)
            {
                errorMsg.Text = "Gender cannot be empty!";
                return;
            }
            else if (check == 4)
            {
                errorMsg.Text = "Address must ends with 'Street'";
                return;
            }
            else if (check == 5)
            {
                errorMsg.Text = "Password must be alphanumeric!";
                return;
            }
            else
            {
                Response.Redirect("~/View/Login.aspx");
                return;
            }
        }
    }
}