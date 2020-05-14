using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigScreen.Models
{
    public class Arena
    {
        public int Id { get; set; }
        public string ArenaName { get; set; }
        public ICollection<ArenaSection> ArenaSections { get; set; }
       
    }
}
