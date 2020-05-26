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
    public class DetailsModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;

        public DetailsModel(BigScreen.Data.BigScreenContext context)
        {
            _context = context;
        }

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
    }
}
