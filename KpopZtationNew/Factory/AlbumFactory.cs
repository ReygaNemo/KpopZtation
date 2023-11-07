using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationNew.Factory
{
    public class AlbumFactory
    {
        public static Album createAlbum(int id, String name, String description, int price, int stock, String image)
        {
            Album a = new Album();

            a.ArtistID = id;
            a.AlbumName = name;
            a.AlbumDescription = description;
            a.AlbumPrice = price;
            a.AlbumStock = stock;
            a.AlbumImage = image;

            return a;
        }
    }
}