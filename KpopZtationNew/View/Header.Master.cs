using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationNew.View
{
    public partial class Header : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                logoutbtn.Visible = true;
                loginlink.Visible = false;
                registerlink.Visible = false;
            }
            else
            {
                logoutbtn.Visible = false;
                loginlink.Visible = true;
                registerlink.Visible = true;
            }
        }

        protected void logoutBtnAction(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Remove("user");
            Session.RemoveAll();
            Session.Abandon();

            Response.Redirect("~/View/Login.aspx");
        }
    }
}