using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtationNew.Controller;

namespace KpopZtationNew.View
{
    public partial class UpdateAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["AlbumId"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["AlbumId"]);
                    List<Album> albums = AlbumController.GetAlbums();

                    Album album = albums.FirstOrDefault(a => a.AlbumID == id);

                    albumId.Value = id.ToString();
                    albumName.Value = album.AlbumName;
                    albumDescription.Value = album.AlbumDescription;
                    albumPrice.Value = album.AlbumPrice.ToString();
                    albumStock.Value = album.AlbumStock.ToString();
                    fileNameLabel.Text = album.AlbumImage;
                }
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            int price;
            int stock;
            int id = Convert.ToInt32(Request.QueryString["AlbumId"]);
            int artistId = Convert.ToInt32(Request.QueryString["ArtistId"]);

            if (!int.TryParse(albumPrice.Value, out price))
            {
                price = 0;
            }
            if (!int.TryParse(albumStock.Value, out stock))
            {
                stock = 0;
            }

            int check = AlbumController.UpdateAlbum(id, albumName.Value, albumDescription.Value, price, stock, albumImage.PostedFile);

            if (check == 1)
            {
                updateError.Text = "Name must be filled and less than 50 characters";
            }
            else if (check == 2)
            {
                updateError.Text = "Description must be filled and less than 255 characters";
            }
            else if (check == 3)
            {
                updateError.Text = "Price must be filled and between 100000 and 1000000";
            }
            else if (check == 4)
            {
                updateError.Text = "Stock must be filled and more than 0";
            }
            else if (check == 5)
            {
                updateError.Text = "Image file must be chosen, have the correct extension (.png, .jpg, .jpeg, .jfif) and must be lower than 2 MB";
            }
            else
            {
                //Response.Redirect("ArtistDetails.aspx?artistId=" + artistId);
                Response.Redirect("Home.aspx");
                return;
            }
        }
    }
}