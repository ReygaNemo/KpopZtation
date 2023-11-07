using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using KpopZtationNew.Handler;

namespace KpopZtationNew.Controller
{
    public class AlbumController
    {
        public static List<Album> GetAlbums()
        {
            return AlbumHandler.GetAlbums();
        }
        public static int InsertAlbum(int id, string name, string description, int price, int stock, HttpPostedFile image)
        {
            string fileExtension = Path.GetExtension(image.FileName).ToLower();
            string[] allowedExtensions = { ".png", ".jpg", ".jpeg", ".jfif" };
            int maxFileSize = 2 * 1024 * 1024;

            if (name.Length <= 0 || name.Length >= 50)
            {
                return 1;
            }
            else if (description.Length <= 0 || name.Length >= 255)
            {
                return 2;
            }
            else if (price == 0 || price < 100000 || price > 1000000)
            {
                return 3;
            }
            else if (stock <= 0)
            {
                return 4;
            }
            else if (!(allowedExtensions.Contains(fileExtension) && image.ContentLength <= maxFileSize))
            {
                return 5;
            }
            return AlbumHandler.InsertAlbum(id, name, description, price, stock, image);
        }
        public static int UpdateAlbum(int id, string name, string description, int price, int stock, HttpPostedFile image)
        {
            string fileExtension = Path.GetExtension(image.FileName).ToLower();
            string[] allowedExtensions = { ".png", ".jpg", ".jpeg", ".jfif" };
            int maxFileSize = 2 * 1024 * 1024;

            if (name.Length <= 0 || name.Length >= 50)
            {
                return 1;
            }
            else if (description.Length <= 0 || name.Length >= 255)
            {
                return 2;
            }
            else if (price == 0 || price < 100000 || price > 1000000)
            {
                return 3;
            }
            else if (stock <= 0)
            {
                return 4;
            }
            else if (!(allowedExtensions.Contains(fileExtension) && image.ContentLength <= maxFileSize))
            {
                return 5;
            }
            return AlbumHandler.UpdateAlbum(id, name, description, price, stock, image);
        }
    }
}