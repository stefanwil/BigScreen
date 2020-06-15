using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigScreen.Models
{
    public class TifoPartScreen
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int TifoPartScreenHeight { get; set; }
        public int TifoPartScreenWidth { get; set; }
        public int AbsScreenHeight { get; set; } //dimensions in mm(or inch)
        public int AbsScreenWidth { get; set; }
        public double DotsPerPixel { get; set; }  //dots/css-pixel
        public int DotsPerInch { get; set; }  //css-pixels/inch or mm?
        public string ApplicationUserId { get; set; } //FK
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<ArenaEventTifoPartScreen> ArenaEventTifoPartScreen { get; set; }

    }
}
