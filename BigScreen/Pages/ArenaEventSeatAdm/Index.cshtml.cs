using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.ArenaEventSeatAdm
{
    public class IndexModel : PageModel
    {
        private readonly BigScreen.Models.BigScreenContext _context;

        public IndexModel(BigScreen.Models.BigScreenContext context)
        {
            _context = context;
        }

        public IList<ArenaEventSeat> ArenaEventSeat { get;set; }

        public async Task OnGetAsync()
        {
            ArenaEventSeat = await _context.ArenaEventSeat
                .Include(a => a.ArenaEvent)
                .Include(a => a.Seat).ToListAsync();
        }
    }
}
