using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BigScreen.Models;

namespace BigScreen.Pages.ArenaEventAdm
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
        ViewData["ArenaSectionId"] = new SelectList(_context.ArenaSection, "Id", "Id");
        ViewData["TifoId"] = new SelectList(_context.Tifo, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ArenaEvent ArenaEvent { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ArenaEvent.Add(ArenaEvent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}