using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.SeatAdm
{
    public class EditModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;

        public EditModel(BigScreen.Data.BigScreenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Seat Seat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seat = await _context.Seat
                .Include(s => s.ArenaSection).FirstOrDefaultAsync(m => m.SeatId == id);

            if (Seat == null)
            {
                return NotFound();
            }
           ViewData["ArenaSectionId"] = new SelectList(_context.ArenaSection, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Seat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatExists(Seat.SeatId))
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

        private bool SeatExists(int id)
        {
            return _context.Seat.Any(e => e.SeatId == id);
        }
    }
}
