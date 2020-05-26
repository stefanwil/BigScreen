using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigScreen.Models
{
    public class TifoGroup
    {
        public int Id { get; set; }
       
        public string TifoGroupName { get; set; }
        public ICollection<Tifo> Tifos { get; set; }
    }
}
