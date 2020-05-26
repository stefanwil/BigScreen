using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigScreen.Models
{
    public class Ticket
    {
       
            public int Id { get; set; }  //TicketId
        public string Title { get; set; }
       
      
            public int? ArenaEventId { get; set; } //FK
            public ArenaEvent ArenaEvent { get; set; }
            public int? SeatId { get; set; } //FK
            public Seat Seat { get; set; }
        public int? TifoId { get; set; } //FK
        public Tifo Tifo { get; set; }


        public string ApplicationUserId { get; set; } //FK
            public ApplicationUser ApplicationUser { get; set; }
        }

    }

