using KpopZtationNew.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationNew.View
{
    public partial class AlbumDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the albumID and artistID query string parameters are provided
                if (Request.QueryString["albumId"] != null && Request.QueryString["artistId"] != null)
                {
                    int albumID = Convert.ToInt32(Request.QueryString["albumId"]);
                    int artistID = Convert.ToInt32(Request.QueryString["artistId"]);

                    // Retrieve the album and artist details based on the IDs
                    // Replace this with your own code to fetch the album and artist details from your data source
                    Album album = GetAlbumDetails(albumID);

                    // Update the controls on the page with the album and artist details
                    if (album != null)
                    {
                        albumNameLabel.Text = album.AlbumName;
                        albumPriceLabel.Text = album.AlbumPrice.ToString();
                        albumDescLabel.Text = album.AlbumDescription;
                        albumStockLabel.Text = album.AlbumStock.ToString();
                    }
                }
            }
        }
        private Album GetAlbumDetails(int albumID)
        {
                using (var dbContext = new DBE())
                {
                    // Retrieve the album details based on the albumID
                    Album album = dbContext.Albums
                        .FirstOrDefault(a => a.AlbumID == albumID);

                    return album;
                }
        }
        private Boolean ValidateQty(int MaxQty)
        {
            if(MaxQty <= Convert.ToInt32(albumStockLabel.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void addToCartBtn_Click(object sender, EventArgs e)
        {
            if(ValidateQty(Convert.ToInt32(quantityInput.Value)) == true)
            {
                // Retrieve the album ID and quantity from the controls
                int albumID = Convert.ToInt32(Request.QueryString["albumID"]);
                int quantity = Convert.ToInt32(quantityInput.Value);

                Customer userTemp = (Customer)Session["user"];
                int UserId = userTemp.CustomerID;
                CartController.AddCart(albumID, UserId, quantity);
                Response.Redirect("ArtistDetails.aspx");
                ShowAlert2();
            }
            else
            {
                ShowAlert();
            }
        }
        protected void checkoutBtn_Click(object sender, EventArgs e)
        {
            // Redirect to the cart page or any other desired page
            Response.Redirect("ViewCart.aspx");
        }
        protected void ShowAlert()
        {
            string alertMessage = "Wrong Qty";
            string script = $@"<script type='text/javascript'>alert('{alertMessage}');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
        }
        protected void ShowAlert2()
        {
            string alertMessage = "Item Added";
            string script = $@"<script type='text/javascript'>alert('{alertMessage}');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
        }

    }
}