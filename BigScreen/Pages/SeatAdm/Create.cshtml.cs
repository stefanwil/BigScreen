using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BigScreen.Models;

namespace BigScreen.Pages.SeatAdm
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
        ViewData["ArenaSectionId"] = new SelectList(_context.ArenaSection, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Seat Seat { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Seat.Add(Seat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}