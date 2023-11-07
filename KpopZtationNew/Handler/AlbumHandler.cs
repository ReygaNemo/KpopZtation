using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtationNew.Repository;

namespace KpopZtationNew.Handler
{
    public class AlbumHandler
    {
        public static int InsertAlbum(int id, string name, string description, int price, int stock, HttpPostedFile image)
        {
            return AlbumRepository.InsertAlbum(id, name, description, price, stock, image);
        }
        public static int UpdateAlbum(int id, string name, string description, int price, int stock, HttpPostedFile image)
        {
            return AlbumRepository.UpdateAlbum(id, name, description, price, stock, image);
        }
        public static List<Album> GetAlbums()
        {
            return AlbumRepository.GetAlbums();
        }
    }
}