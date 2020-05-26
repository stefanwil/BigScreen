using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigScreen.Data;
using BigScreen.Models;

namespace BigScreen.Pages.TicketAdm
{
    public class EditModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;

        public EditModel(BigScreen.Data.BigScreenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _context.Ticket
                .Include(t => t.ApplicationUser)
                .Include(t => t.ArenaEvent)
                .Include(t => t.Seat)
                .Include(t => t.Tifo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Ticket == null)
            {
                return NotFound();
            }
           ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
           ViewData["ArenaEventId"] = new SelectList(_context.ArenaEvent, "Id", "Id");
           ViewData["SeatId"] = new SelectList(_context.Seat, "SeatId", "SeatId");
            ViewData["TifoId"] = new SelectList(_context.Tifo, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(Ticket.Id))
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

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}
