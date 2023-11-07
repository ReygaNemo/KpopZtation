using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtationNew.Handler;
using System.IO;

namespace KpopZtationNew.Controller
{
    public class ArtistController
    {
        public static List<Artist> GetArtists()
        {
            return ArtistHandler.GetArtists();
        }
        public static int InsertArtist(string name, HttpPostedFile image)
        {
            int nameflag = 0;
            int imageflag = 0;

            DBE db = new DBE();
            List<Artist> artists = (from a in db.Artists select a).ToList();

            if (artists.Count > 0)
            {
                foreach (Artist artist in artists)
                {
                    if (artist.ArtistName == name)
                    {
                        nameflag = 0;
                        break;
                    }
                    else
                    {
                        nameflag = 1;
                    }
                }
            }
            else
            {
                nameflag = 1;
            }

            string fileExtension = Path.GetExtension(image.FileName).ToLower();
            string[] allowedExtensions = { ".png", ".jpg", ".jpeg", ".jfif" };
            int maxFileSize = 2 * 1024 * 1024;

            if (allowedExtensions.Contains(fileExtension) && image.ContentLength <= maxFileSize)
            {
                imageflag = 1;
            }
            else
            {
                imageflag = 0;
            }

            if (nameflag == 0)
            {
                return 1;
            }
            else if (imageflag == 0)
            {
                return 2;
            }
            return ArtistHandler.InsertArtist(name, image);
        }
        public static Boolean UpdateArtist(int id, string name, HttpPostedFile imageFile)
        {
            int nameflag = 0;
            int imageflag = 0;

            DBE db = new DBE();
            List<Artist> artists = (from a in db.Artists select a).ToList();

            if (artists.Count > 0)
            {
                foreach (Artist artist in artists)
                {
                    if (artist.ArtistName == name && artist.ArtistID != id)
                    {
                        nameflag = 0;
                        break;
                    }
                    else
                    {
                        nameflag = 1;
                    }
                }
            }
            else
            {
                nameflag = 1;
            }

            string fileExtension = Path.GetExtension(imageFile.FileName).ToLower();
            string[] allowedExtensions = { ".png", ".jpg", ".jpeg", ".jfif" };
            int maxFileSize = 2 * 1024 * 1024;

            if (allowedExtensions.Contains(fileExtension) && imageFile.ContentLength <= maxFileSize)
            {
                imageflag = 1;
            }
            else
            {
                imageflag = 0;
            }

            if (nameflag == 0 || imageflag == 0)
            {
                return false;
            }
            return ArtistHandler.UpdateArtist(id, name, imageFile);
        }
        public static Boolean DeleteArtist(int id)
        {
            return ArtistHandler.DeleteArtist(id);
        }
    }
}