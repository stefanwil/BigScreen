using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BigScreen.Models
{
    public class ArenaEventSeat
    {
        
        public int ArenaEventId { get; set; }
        public ArenaEvent ArenaEvent { get; set; }
        
        public int SeatId { get; set; }
        public Seat Seat { get; set; }
        public bool Registered { get; set; }
    }
}
