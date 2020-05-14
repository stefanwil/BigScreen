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
    public class DeleteModel : PageModel
    {
        private readonly BigScreen.Models.BigScreenContext _context;

        public DeleteModel(BigScreen.Models.BigScreenContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ArenaEventSeat = await _context.ArenaEventSeat.FindAsync(id);

            if (ArenaEventSeat != null)
            {
                _context.ArenaEventSeat.Remove(ArenaEventSeat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
