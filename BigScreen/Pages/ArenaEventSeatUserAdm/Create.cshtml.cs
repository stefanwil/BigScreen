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

namespace BigScreen.Pages.ArenaEventSeatUserAdm
{
    public class CreateModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CreateModel(BigScreen.Data.BigScreenContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["ArenaEventId"] = new SelectList(_context.ArenaEvent, "Id", "Id");
            ViewData["SeatId"] = new SelectList(_context.Seat, "SeatId", "SeatId");

            var userName = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);
            ViewData["UserId"] = user.Id;
    

            return Page();
        }

        [BindProperty]
        public ArenaEventSeat ArenaEventSeat { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ArenaEventSeat.Add(ArenaEventSeat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}