using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.ArenaEventAdm
{
    public class DeleteModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;

        public DeleteModel(BigScreen.Data.BigScreenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ArenaEvent ArenaEvent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ArenaEvent = await _context.ArenaEvent
             
                .Include(a => a.Tifo).FirstOrDefaultAsync(m => m.Id == id);

            if (ArenaEvent == null)
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

            ArenaEvent = await _context.ArenaEvent.FindAsync(id);

            if (ArenaEvent != null)
            {
                _context.ArenaEvent.Remove(ArenaEvent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
