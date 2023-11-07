using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationNew.Factory
{
    public class ArtistFactory
    {
        public static Artist createArtist(String name, String image)
        {
            Artist a = new Artist();

            a.ArtistName = name;
            a.ArtistImage = image;

            return a;
        }
    }
}