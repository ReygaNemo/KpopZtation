using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtationNew.Model;

namespace KpopZtationNew.View
{
    public partial class ArtistDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ArtistId"] != null)
                {
                    int artistId = Convert.ToInt32(Request.QueryString["ArtistId"]);
                    string artistName = GetArtistName(artistId);
                    string artistImg = GetImageLinks(artistId);
                    List<AlbumDto> artistAlbums = GetArtistAlbums(artistId);

                    artistNameLabel.Text = artistName;
                    artistImage.ImageUrl = "../Assets/Artists/" + artistImg;

                    albumsRepeater.DataSource = artistAlbums;
                    albumsRepeater.DataBind();
                }
            }
        }
        private string GetArtistName(int artistId)
        {
            using (DBE db = new DBE())
            {
                return db.Artists.Where(a => a.ArtistID == artistId).Select(a => a.ArtistName).FirstOrDefault();
            }
        }
        private string GetImageLinks(int artistId)
        {
            using (DBE db = new DBE())
            {
                return db.Artists.Where(a => a.ArtistID == artistId).Select(a => a.ArtistImage).FirstOrDefault();
            }
        }
        private List<AlbumDto> GetArtistAlbums(int artistId)
        {
            using (DBE db = new DBE())
            {
                var albumsData = db.Albums
                .Where(a => a.ArtistID == artistId)
                .Select(a => new AlbumDto
                {
                    AlbumID = a.AlbumID,
                    AlbumName = a.AlbumName,
                    AlbumDescription = a.AlbumDescription,
                    AlbumImage = a.AlbumImage,
                    AlbumPrice = a.AlbumPrice,
                    AlbumStock = a.AlbumStock
                })
                .ToList();

                return albumsData;
            }
        }
        protected void insertAlbumBtn_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ArtistId"] != null)
            {
                int artistId = Convert.ToInt32(Request.QueryString["ArtistId"]);
                Response.Redirect("~/View/InsertAlbum.aspx?artistId="+artistId);
            }
        }
    }
}