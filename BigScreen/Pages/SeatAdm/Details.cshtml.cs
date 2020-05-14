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
    public class DetailsModel : PageModel
    {
        private readonly BigScreen.Models.BigScreenContext _context;

        public DetailsModel(BigScreen.Models.BigScreenContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
