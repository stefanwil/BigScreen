using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;

namespace BigScreen.Pages.TicketAdm
{
    public class PlayTicketModel : PageModel
    {

        private readonly BigScreen.Data.BigScreenContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        //private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(User);
        public PlayTicketModel(BigScreen.Data.BigScreenContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        [BindProperty]
        public Ticket Ticket { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = await _userManager.GetUserIdAsync(user);
      
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _context.Ticket
                .Include(t => t.ApplicationUser)
                .Include(t => t.ArenaEvent)
                .Include(t => t.Seat).ThenInclude(u=>u.ArenaSection)
                .Include(t => t.Tifo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Ticket == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = userId;
       
            ViewData["ArenaEventId"] = Ticket.ArenaEventId;
            ViewData["SeatId"] = Ticket.SeatId;
            ViewData["TifoId"] = Ticket.TifoId;


            return Page();

        }

      

        public async Task<IActionResult> OnPostAsync( )
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ticket.Add(Ticket);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}