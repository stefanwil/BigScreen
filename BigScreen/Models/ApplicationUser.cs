using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BigScreen.Models
{
  
        public class ApplicationUser : IdentityUser
        {
        [Key]
        override public string Id { get; set; }

        [Display(Name = "Namn")]
            public string Name { get; set; }

        public ICollection<TifoPartScreen> TifoPartScreen { get; set; }
        public ICollection<UserSeat> UserSeats { get; set; }
    }
    
}
