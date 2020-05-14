﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BigScreen.Models;

namespace BigScreen.Pages.ArenaAdm
{
    public class CreateModel : PageModel
    {
        private readonly BigScreen.Models.BigScreenContext _context;

        public CreateModel(BigScreen.Models.BigScreenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Arena Arena { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Arena.Add(Arena);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}