using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using KpopZtationNew.Factory;

namespace KpopZtationNew.Repository
{
    public class ArtistRepository
    {
        public static List<Artist> GetArtists()
        {
            DBE db = new DBE();
            List<Artist> artists = (from a in db.Artists select a).ToList();
            return artists;
        }
        public static Boolean UpdateArtist(int id, string name, HttpPostedFile image)
        {
            string updatedImage = null;
            string updatedFileName = null;

            using (DBE db = new DBE())
            {
                Artist artist = db.Artists.FirstOrDefault(a => a.ArtistID == id);
                if (artist != null)
                {
                    artist.ArtistName = name;

                    if (image != null && image.ContentLength > 0)
                    {
                        updatedFileName = Path.GetFileName(image.FileName);
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(updatedFileName);
                        string filePath = GetServerRelativePath("~/Assets/Artists/" + fileName);
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
                        artist.ArtistImage = updatedImage;
                    }
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public static int InsertArtist(string name, HttpPostedFile image)
        {
            DBE db = new DBE();

            string imageName = image.FileName;

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageName);
            string filePath = GetServerRelativePath("~/Assets/Artists/" + fileName);
            image.SaveAs(filePath);

            Artist a = ArtistFactory.createArtist(name, fileName);

            db.Artists.Add(a);
            db.SaveChanges();

            return 0;
        }
        private static string GetServerRelativePath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
        public static Boolean DeleteArtist(int id)
        {
            using (DBE db = new DBE())
            {
                var artist = db.Artists.FirstOrDefault(a => a.ArtistID == id);
                var albumsData = db.Albums.Where(a => a.ArtistID == id).ToList();

                if (artist != null)
                {
                    foreach (var album in albumsData)
                    {
                        db.Albums.Remove(album);
                    }
                    db.Artists.Remove(artist);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}