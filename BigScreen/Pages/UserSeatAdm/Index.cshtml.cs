using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.UserSeatAdm
{
    public class IndexModel : PageModel
    {
        private readonly BigScreen.Models.BigScreenContext _context;

        public IndexModel(BigScreen.Models.BigScreenContext context)
        {
            _context = context;
        }

        public IList<UserSeat> UserSeat { get;set; }

        public async Task OnGetAsync()
        {
            UserSeat = await _context.UserSeat
                .Include(u => u.ApplicationUser)
                .Include(u => u.Seat).ToListAsync();
        }
    }
}
