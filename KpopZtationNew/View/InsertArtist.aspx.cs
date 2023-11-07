using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtationNew.Controller;

namespace KpopZtationNew.View
{
    public partial class InsertArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void insertButton_Click(object sender, EventArgs e)
        {
            int check = ArtistController.InsertArtist(artistName.Value, artistImage.PostedFile);

            if (check == 1)
            {
                insertError.Text = "Name must be filled and unique";
            }
            else if (check == 2)
            {
                insertError.Text = "Image file must be chosen, have the correct extension (.png, .jpg, .jpeg, .jfif) and must be lower than 2 MB";
            }
            else
            {
                Response.Redirect("Home.aspx");
                return;
            }
        }
    }
}