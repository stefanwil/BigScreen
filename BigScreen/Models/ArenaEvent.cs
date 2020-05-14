using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BigScreen.Models
{
    public class ArenaEvent
    {
       [Key]
        public int Id { get; set; }
        
        public string EventName { get; set; }  //Name for this event example AIK-DIF Final
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Date of event")]
        public DateTime EventDate { get; set; }
       
        public string ContentType { get; set; }
        public string LengthOfMedia { get; set; }
        public int TifoId { get; set; } //FK
        public Tifo Tifo { get; set; } //
      

        public ICollection<ArenaEventTifoPartScreen> ArenaEventTifoPartScreen { get; set; }
        public ICollection<ArenaEventSeat> ArenaEventSeat { get; set; }
    }
}