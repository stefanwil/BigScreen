using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.ArenaEventTifoPartScreenAdm
{
    public class EditModel : PageModel
    {
        private readonly BigScreen.Models.BigScreenContext _context;

        public EditModel(BigScreen.Models.BigScreenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ArenaEventTifoPartScreen ArenaEventTifoPartScreen { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ArenaEventTifoPartScreen = await _context.ArenaEventTifoPartScreen
                .Include(a => a.ArenaEvent)
                .Include(a => a.TifoPartScreen).FirstOrDefaultAsync(m => m.ArenaEventId == id);

            if (ArenaEventTifoPartScreen == null)
            {
                return NotFound();
            }
           ViewData["TifoPartScreenId"] = new SelectList(_context.ArenaEvent, "Id", "Id");
           ViewData["ArenaEventId"] = new SelectList(_context.TifoPartScreen, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ArenaEventTifoPartScreen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArenaEventTifoPartScreenExists(ArenaEventTifoPartScreen.ArenaEventId))
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

        private bool ArenaEventTifoPartScreenExists(int id)
        {
            return _context.ArenaEventTifoPartScreen.Any(e => e.ArenaEventId == id);
        }
    }
}
