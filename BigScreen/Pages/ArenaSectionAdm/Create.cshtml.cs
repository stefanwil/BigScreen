using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BigScreen.Models;

namespace BigScreen.Pages.ArenaSectionAdm
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
        ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ArenaSection ArenaSection { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ArenaSection.Add(ArenaSection);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}