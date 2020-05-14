using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BigScreen.Models;

namespace BigScreen.Pages.ArenaEventSeatAdm
{
    public class CreateModel : PageModel
    {
        private readonly BigScreen.Models.BigScreenContext _context;

        public CreateModel(BigScreen.Models.BigScreenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ArenaEventId"] = new SelectList(_context.ArenaEvent, "ArenaEventId", "ArenaEventId");
        ViewData["SeatId"] = new SelectList(_context.Seat, "SeatId", "SeatId");
            return Page();
        }

        [BindProperty]
        public ArenaEventSeat ArenaEventSeat { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ArenaEventSeat.Add(ArenaEventSeat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}