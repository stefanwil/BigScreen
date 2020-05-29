using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigScreen.Models
{
    public class Videoinfo
    {
        public string Id { get; set; } //Id
        public string VideoHeight { get; set; } //Size in pixels example 1056*1920
        public string VideoWidth { get; set; } //Size in pixels example 1056*1920
        public string Title { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
        public string LengthOfMedia { get; set; }

    }
}
