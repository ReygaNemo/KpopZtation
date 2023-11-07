using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationNew.Model
{
    public class AlbumDto
    {
        public int AlbumID { get; set; }
        public int ArtistID { get; set; }
        public string AlbumName { get; set; }
        public string AlbumDescription { get; set; }
        public string AlbumImage { get; set; }
        public int AlbumPrice { get; set; }
        public int AlbumStock { get; set; }
    }
}