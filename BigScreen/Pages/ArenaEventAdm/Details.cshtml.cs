﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.ArenaEventAdm
{
    public class DetailsModel : PageModel
    {
        private readonly BigScreen.Models.BigScreenContext _context;

        public DetailsModel(BigScreen.Models.BigScreenContext context)
        {
            _context = context;
        }

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
    }
}
