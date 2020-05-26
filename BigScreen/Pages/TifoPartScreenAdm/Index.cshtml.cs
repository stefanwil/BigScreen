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
    public class IndexModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;

        public IndexModel(BigScreen.Data.BigScreenContext context)
        {
            _context = context;
        }

        public IList<TifoPartScreen> TifoPartScreen { get;set; }

        public async Task OnGetAsync()
        {
            TifoPartScreen = await _context.TifoPartScreen.ToListAsync();
        }
    }
}
