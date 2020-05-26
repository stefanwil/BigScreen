using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BigScreen.Data;
using BigScreen.Models;

namespace BigScreen.Pages.TifoGroupAdm
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
            return Page();
        }

        [BindProperty]
        public TifoGroup TifoGroup { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TifoGroup.Add(TifoGroup);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}