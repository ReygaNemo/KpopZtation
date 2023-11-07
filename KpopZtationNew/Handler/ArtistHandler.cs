using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtationNew.Repository;

namespace KpopZtationNew.Handler
{
    public class ArtistHandler
    {
        public static List<Artist> GetArtists()
        {
            return ArtistRepository.GetArtists();
        }
        public static Boolean UpdateArtist(int id, string name, HttpPostedFile image)
        {
            return ArtistRepository.UpdateArtist(id, name, image);
        }
        public static Boolean DeleteArtist(int id)
        {
            return ArtistRepository.DeleteArtist(id);
        }
        public static int InsertArtist(string name, HttpPostedFile image)
        {
            return ArtistRepository.InsertArtist(name, image);
        }
    }
}