﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.ArenaEventTifoPartScreenAdm
{
    public class IndexModel : PageModel
    {
        private readonly BigScreen.Models.BigScreenContext _context;

        public IndexModel(BigScreen.Models.BigScreenContext context)
        {
            _context = context;
        }

        public IList<ArenaEventTifoPartScreen> ArenaEventTifoPartScreen { get;set; }

        public async Task OnGetAsync()
        {
            ArenaEventTifoPartScreen = await _context.ArenaEventTifoPartScreen
                .Include(a => a.ArenaEvent)
                .Include(a => a.TifoPartScreen).ToListAsync();
        }
    }
}
