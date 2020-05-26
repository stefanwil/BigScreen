using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BigScreen.Data;
using BigScreen.Models;

namespace BigScreen.Pages.TicketAdm
{
    public class CreateModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        //private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(User);
        public CreateModel(BigScreen.Data.BigScreenContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public async Task<IActionResult> OnGetAsync()
        {
      
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = await _userManager.GetUserIdAsync(user);
         
            ViewData["ApplicationUserId"] = userId;
            //ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
        ViewData["ArenaEventId"] = new SelectList(_context.ArenaEvent, "Id", "Id");
        ViewData["SeatId"] = new SelectList(_context.Seat, "SeatId", "SeatId");
        ViewData["TifoId"] = new SelectList(_context.Tifo, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Ticket.Tifo = null;  //Sätts till null för att undvika insert av null tifo
                _context.Add(Ticket);
                await _context.SaveChangesAsync();
                TempData["SuccessText"] = $"Dokument: {Ticket.Title} skapades Ok!";
                return RedirectToPage("./Index");
            }



            if (!ModelState.IsValid)
            {
                return Page();
            }
            Ticket.Tifo = null;
            _context.Ticket.Add(Ticket);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}