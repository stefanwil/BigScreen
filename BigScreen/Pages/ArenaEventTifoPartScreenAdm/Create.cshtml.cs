using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BigScreen.Models;

namespace BigScreen.Pages.ArenaEventTifoPartScreenAdm
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
        ViewData["TifoPartScreenId"] = new SelectList(_context.ArenaEvent, "Id", "Id");
        ViewData["ArenaEventId"] = new SelectList(_context.TifoPartScreen, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ArenaEventTifoPartScreen ArenaEventTifoPartScreen { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ArenaEventTifoPartScreen.Add(ArenaEventTifoPartScreen);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}