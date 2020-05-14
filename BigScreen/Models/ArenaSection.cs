using System.Collections.Generic;

namespace BigScreen.Models
{
    public class ArenaSection
    {
        public int Id { get; set; }
        public int ArenaId { get; set; } //FK
        public Arena Arena { get; set; }
        public int SectionHeight { get; set; }  //Size in mm
        public int SectionWidth { get; set; }

        public ICollection<Seat> Seats { get; set; }
        


    }
}