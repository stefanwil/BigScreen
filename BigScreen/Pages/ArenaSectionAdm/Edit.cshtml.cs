using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.ArenaSectionAdm
{
    public class EditModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;

        public EditModel(BigScreen.Data.BigScreenContext context)
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
           ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ArenaSection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArenaSectionExists(ArenaSection.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArenaSectionExists(int id)
        {
            return _context.ArenaSection.Any(e => e.Id == id);
        }
    }
}
