using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.TifoAdm
{
    public class DeleteModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;

        public DeleteModel(BigScreen.Data.BigScreenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tifo Tifo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tifo = await _context.Tifo.FirstOrDefaultAsync(m => m.Id == id);

            if (Tifo == null)
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

            Tifo = await _context.Tifo.FindAsync(id);

            if (Tifo != null)
            {
                _context.Tifo.Remove(Tifo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
