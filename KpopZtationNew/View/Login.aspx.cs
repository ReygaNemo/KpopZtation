using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtationNew.Controller;

namespace KpopZtationNew.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the RememberMe cookie exists
                if (Request.Cookies["RememberMe"] != null)
                {
                    HttpCookie cookie = Request.Cookies["RememberMe"];

                    string email = cookie.Values["Email"];
                    string password = cookie.Values["Password"];

                    emailLogin.Text = email;
                    passwordLogin.Text = password;
                    rememberMeCheckbox.Checked = true;
                }
            }
        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            string email = emailLogin.Text;
            string password = passwordLogin.Text;

            if (!CustomerController.Login(email, password))
            {
                loginError.Text = "Incorrect Credentials!";
                return;
            }
            DBE db = new DBE();

            Customer user = (from u in db.Customers where u.CustomerEmail.Equals(email) && u.CustomerPassword.Equals(password) select u).FirstOrDefault();

            if (user != null)
            {
                if (rememberMeCheckbox.Checked)
                {
                    HttpCookie cookie = new HttpCookie("RememberMe");
                    cookie.Values["Email"] = email;
                    cookie.Values["Password"] = password;
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    if (Request.Cookies["RememberMe"] != null)
                    {
                        HttpCookie cookie = new HttpCookie("RememberMe");
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(cookie);
                    }
                }
                Session["user"] = user;
            }
            Response.Redirect("~/View/Home.aspx");
            return;
        }
    }
}