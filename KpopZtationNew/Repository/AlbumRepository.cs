using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using KpopZtationNew.Factory;

namespace KpopZtationNew.Repository
{
    public class AlbumRepository
    {
        public static List<Album> GetAlbums()
        {
            DBE db = new DBE();
            List<Album> albums = (from a in db.Albums select a).ToList();
            return albums;
        }
        public static int InsertAlbum(int id, string name, string description, int price, int stock, HttpPostedFile image)
        {
            DBE db = new DBE();

            string imageName = image.FileName;

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageName);
            string filePath = GetServerRelativePath("~/Assets/Albums/" + fileName);
            image.SaveAs(filePath);

            Album a = AlbumFactory.createAlbum(id, name, description, price, stock, fileName);

            db.Albums.Add(a);
            db.SaveChanges();

            return 0;
        }
        public static int UpdateAlbum(int id, string name, string description, int price, int stock, HttpPostedFile image)
        {
            string updatedImage = null;
            string updatedFileName = null;

            using (DBE db = new DBE())
            {
                Album album = db.Albums.FirstOrDefault(a => a.AlbumID == id);

                if (album != null)
                {
                    album.AlbumName = name;
                    album.AlbumDescription = description;
                    album.AlbumPrice = price;
                    album.AlbumStock = stock;

                    if (image != null && image.ContentLength > 0)
                    {
                        updatedFileName = Path.GetFileName(image.FileName);
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(updatedFileName);
                        string filePath = GetServerRelativePath("~/Assets/Albums/" + fileName);
                        image.SaveAs(filePath);
                        updatedImage = fileName;
                    }
                    else
                    {
                        updatedFileName = Path.GetFileName(image.FileName);
                        updatedImage = updatedFileName;
                    }

                    if (!string.IsNullOrEmpty(updatedImage))
                    {
                        album.AlbumImage = updatedImage;
                    }
                    db.SaveChanges();
                }
            }
            return 0;
        }
        private static string GetServerRelativePath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
    }
}