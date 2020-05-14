using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigScreen.Models
{
    public class UserSeat
    {
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int SeatId { get; set; }
        public Seat Seat { get; set; }

    }
}
