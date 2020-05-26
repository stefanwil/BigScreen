using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BigScreen.Data;
using BigScreen.Models;

namespace BigScreen.Pages.TicketAdm
{
    public class DetailsModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;

        public DetailsModel(BigScreen.Data.BigScreenContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
