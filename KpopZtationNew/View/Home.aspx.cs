using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtationNew.Controller;

namespace KpopZtationNew.View
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Artist> artists = ArtistController.GetArtists();

                artistRepeater.DataSource = artists;
                artistRepeater.DataBind();
            }
        }
        protected void DeleteArtist_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            int artistId = Convert.ToInt32(btnDelete.CommandArgument);

            if(ArtistController.DeleteArtist(artistId))
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertArtist.aspx");
        }
    }
}