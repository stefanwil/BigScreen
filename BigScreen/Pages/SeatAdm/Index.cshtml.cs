using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.SeatAdm
{
    public class IndexModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;

        public IndexModel(BigScreen.Data.BigScreenContext context)
        {
            _context = context;
        }

        public IList<Seat> Seat { get;set; }

        public async Task OnGetAsync()
        {
            Seat = await _context.Seat
                .Include(s => s.ArenaSection).ToListAsync();
        }
    }
}
