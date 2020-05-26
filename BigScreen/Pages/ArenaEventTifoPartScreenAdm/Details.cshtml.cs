using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.ArenaEventTifoPartScreenAdm
{
    public class DetailsModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;

        public DetailsModel(BigScreen.Data.BigScreenContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
