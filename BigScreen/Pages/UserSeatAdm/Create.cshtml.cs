using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BigScreen.Models;

namespace BigScreen.Pages.UserSeatAdm
{
    public class CreateModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;

        public CreateModel(BigScreen.Data.BigScreenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
       ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
        ViewData["SeatId"] = new SelectList(_context.Seat, "SeatId", "SeatId");
            return Page();
        }

        [BindProperty]
        public UserSeat UserSeat { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserSeat.Add(UserSeat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}