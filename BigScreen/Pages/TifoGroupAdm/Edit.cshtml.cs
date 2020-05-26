using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigScreen.Data;
using BigScreen.Models;

namespace BigScreen.Pages.TifoGroupAdm
{
    public class EditModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;

        public EditModel(BigScreen.Data.BigScreenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TifoGroup TifoGroup { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TifoGroup = await _context.TifoGroup.FirstOrDefaultAsync(m => m.Id == id);

            if (TifoGroup == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TifoGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TifoGroupExists(TifoGroup.Id))
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

        private bool TifoGroupExists(int id)
        {
            return _context.TifoGroup.Any(e => e.Id == id);
        }
    }
}
