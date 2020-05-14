using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BigScreen.Models
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; }
        [Display(Name = "Rad")]
        public int SectionRow { get; set; }
        [Display(Name = "Kolumn")]
        public int SectionColumn { get; set; }

        [Display(Name = "Bredd")]
        public string SeatWidth { get; set; }  //In Millimeters
        [Display(Name = "Höjd")]
        public string SeatHeight { get; set; }
       
        public int ArenaSectionId { get; set; } //FK
        public ArenaSection ArenaSection { get; set; }
        public ICollection<UserSeat> UserSeats { get; set; }
        //public ICollection<ArenaEventSeat> ArenaEventSeat { get; set; }
    }


}
   

