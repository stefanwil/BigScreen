using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.ArenaAdm
{
    public class DeleteModel : PageModel
    {
        private readonly BigScreen.Models.BigScreenContext _context;

        public DeleteModel(BigScreen.Models.BigScreenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Arena Arena { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Arena = await _context.Arena.FirstOrDefaultAsync(m => m.Id == id);

            if (Arena == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Arena = await _context.Arena.FindAsync(id);

            if (Arena != null)
            {
                _context.Arena.Remove(Arena);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
