using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.UserSeatAdm
{
    public class DeleteModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;

        public DeleteModel(BigScreen.Data.BigScreenContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserSeat = await _context.UserSeat.FindAsync(id);

            if (UserSeat != null)
            {
                _context.UserSeat.Remove(UserSeat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
