using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.UserSeatAdm
{
    public class EditModel : PageModel
    {
        private readonly BigScreen.Models.BigScreenContext _context;

        public EditModel(BigScreen.Models.BigScreenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserSeat UserSeat { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserSeat = await _context.UserSeat
                .Include(u => u.ApplicationUser)
                .Include(u => u.Seat).FirstOrDefaultAsync(m => m.UserId == id);

            if (UserSeat == null)
            {
                return NotFound();
            }
          ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
           ViewData["SeatId"] = new SelectList(_context.Seat, "SeatId", "SeatId");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserSeat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSeatExists(UserSeat.UserId))
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

        private bool UserSeatExists(string id)
        {
            return _context.UserSeat.Any(e => e.UserId == id);
        }
    }
}
