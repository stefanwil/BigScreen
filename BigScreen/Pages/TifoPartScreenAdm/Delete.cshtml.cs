using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.TifoPartScreenAdm
{
    public class DeleteModel : PageModel
    {
        private readonly BigScreen.Models.BigScreenContext _context;

        public DeleteModel(BigScreen.Models.BigScreenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TifoPartScreen TifoPartScreen { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TifoPartScreen = await _context.TifoPartScreen.FirstOrDefaultAsync(m => m.Id == id);

            if (TifoPartScreen == null)
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

            TifoPartScreen = await _context.TifoPartScreen.FindAsync(id);

            if (TifoPartScreen != null)
            {
                _context.TifoPartScreen.Remove(TifoPartScreen);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
