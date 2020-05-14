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
    public class DetailsModel : PageModel
    {
        private readonly BigScreen.Models.BigScreenContext _context;

        public DetailsModel(BigScreen.Models.BigScreenContext context)
        {
            _context = context;
        }

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
    }
}
