using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggerToHugo.Model
{

    public class ImageMeta
    {
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string imageViews { get; set; }
        public Creationtime creationTime { get; set; }
        public Modificationtime modificationTime { get; set; }
        public Geodata geoData { get; set; }
        public Geodataexif geoDataExif { get; set; }
    }

    public class Creationtime
    {
        public string timestamp { get; set; }
        public string formatted { get; set; }
    }

    public class Modificationtime
    {
        public string timestamp { get; set; }
        public string formatted { get; set; }
    }

    public class Geodata
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public float altitude { get; set; }
        public float latitudeSpan { get; set; }
        public float longitudeSpan { get; set; }
    }

    public class Geodataexif
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public float altitude { get; set; }
        public float latitudeSpan { get; set; }
        public float longitudeSpan { get; set; }
    }
}
