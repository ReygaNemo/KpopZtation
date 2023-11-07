using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtationNew.Controller;

namespace KpopZtationNew.View
{
    public partial class UpdateArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ArtistId"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["ArtistId"]);
                    List<Artist> artists = ArtistController.GetArtists();
                    Artist artist = artists.FirstOrDefault(a => a.ArtistID == id);

                    artistId.Value = id.ToString();
                    artistName.Value = artist.ArtistName;
                    fileNameLabel.Text = artist.ArtistImage;
                }
            }
        }
        protected void updateButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(artistId.Value);
            string name = artistName.Value;

            if (ArtistController.UpdateArtist(id, name, artistImage.PostedFile))
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                updateError.Text = "All fields must be filled correctly";
                return;
            }
        }
    }
}