using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BigScreen.Data;
using BigScreen.Models;

namespace BigScreen.Pages.TicketAdm
{
    public class IndexModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
 

  
        public IndexModel(BigScreen.Data.BigScreenContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Ticket> Ticket { get;set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = await _userManager.GetUserIdAsync(user);
           
            Ticket = await _context.Ticket
                //.Include(t => t.ApplicationUser).Where(t=>t.ApplicationUserId==userId)
                              .Include(t => t.ApplicationUser)
                .Include(t => t.ArenaEvent)
                .Include(t => t.Seat)
                .Include(t => t.Tifo)
                .ToListAsync();
        }
    }
}
