using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.ArenaEventSeatAdm
{
    public class EditModel : PageModel
    {
        private readonly BigScreen.Models.BigScreenContext _context;

        public EditModel(BigScreen.Models.BigScreenContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["SeatId"] = new SelectList(_context.ArenaEvent, "ArenaEventId", "ArenaEventId");
           ViewData["ArenaEventId"] = new SelectList(_context.Seat, "SeatId", "SeatId");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ArenaEventSeat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArenaEventSeatExists(ArenaEventSeat.ArenaEventId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArenaEventSeatExists(int id)
        {
            return _context.ArenaEventSeat.Any(e => e.ArenaEventId == id);
        }
    }
}
