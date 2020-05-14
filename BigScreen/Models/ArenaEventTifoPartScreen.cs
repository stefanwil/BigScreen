using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigScreen.Models
{
    public class ArenaEventTifoPartScreen
    {
        public int ArenaEventId { get; set; }
        public ArenaEvent ArenaEvent { get; set; }

        public int TifoPartScreenId { get; set; }
        public TifoPartScreen TifoPartScreen { get; set; }

    }
}
