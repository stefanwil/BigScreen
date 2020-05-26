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
    public class DeleteModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;

        public DeleteModel(BigScreen.Data.BigScreenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ArenaEventSeat ArenaEventSeat { get; set; }
        
        public async Task<IActionResult> OnGetAsync([Bind("ArenaEventId,SeatId")]int? arenaEventId, int? seatId)
        {
            if (arenaEventId == null | (seatId == null))
            {
                return NotFound();
            }

            ArenaEventSeat = await _context.ArenaEventSeat
                .Include(a => a.ArenaEvent)
                .Include(a => a.Seat).FirstOrDefaultAsync(m => m.ArenaEventId == arenaEventId & m.SeatId==seatId);

            if (ArenaEventSeat == null)
            {
                return NotFound();
            }
            return Page();
        }
    
        public async Task<IActionResult> OnPostAsync([Bind("ArenaEventId,SeatId")]int? arenaEventId, int? seatId)
        {
            if (arenaEventId == null| (seatId == null))
            {
                return NotFound();
            }

            ArenaEventSeat = await _context.ArenaEventSeat.FindAsync(arenaEventId,seatId  );

            if (ArenaEventSeat != null)
            {
                _context.ArenaEventSeat.Remove(ArenaEventSeat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
