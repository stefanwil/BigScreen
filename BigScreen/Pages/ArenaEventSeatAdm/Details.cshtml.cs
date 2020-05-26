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
    public class DetailsModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;

        public DetailsModel(BigScreen.Data.BigScreenContext context)
        {
            _context = context;
        }

        public ArenaEventSeat ArenaEventSeat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ArenaEventSeat = await _context.ArenaEventSeat
                .Include(a => a.ArenaEvent)
                .Include(a => a.Seat).FirstOrDefaultAsync(m => m.ArenaEventId == id);

            if (ArenaEventSeat == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
