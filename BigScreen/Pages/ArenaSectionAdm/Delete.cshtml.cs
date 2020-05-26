using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.ArenaSectionAdm
{
    public class DeleteModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;

        public DeleteModel(BigScreen.Data.BigScreenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ArenaSection ArenaSection { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ArenaSection = await _context.ArenaSection
                .Include(a => a.Arena).FirstOrDefaultAsync(m => m.Id == id);

            if (ArenaSection == null)
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

            ArenaSection = await _context.ArenaSection.FindAsync(id);

            if (ArenaSection != null)
            {
                _context.ArenaSection.Remove(ArenaSection);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
