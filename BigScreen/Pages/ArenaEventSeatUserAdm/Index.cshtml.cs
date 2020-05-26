using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BigScreen.Data;
using BigScreen.Models;

namespace BigScreen.Pages.ArenaEventSeatUserAdm
{
    public class IndexModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;

        public IndexModel(BigScreen.Data.BigScreenContext context)
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
