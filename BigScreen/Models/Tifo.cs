using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BigScreen.Models
{
    public class Tifo
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
        public long LengthOfMedia { get; set; }
        public int TifoHeight { get; set; } //Size in pixels example 1056*1920
        public int TifoWidth { get; set; } //Size in pixels example 1056*1920
        [NotMapped]
        public IFormFile MyUploadedFile { set; get; }
        public ICollection<ArenaEvent> ArenaEvents { get; set; }
  
    }
}
