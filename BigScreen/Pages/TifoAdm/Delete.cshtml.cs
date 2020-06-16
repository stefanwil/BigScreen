using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BigScreen.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace BigScreen.Pages.TifoAdm
{
    public class DeleteModel : PageModel
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly BigScreen.Data.BigScreenContext _context;

        public DeleteModel(BigScreen.Data.BigScreenContext context, IHostingEnvironment environment)
        {
            _context = context;
            hostingEnvironment = environment;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tifo = await _context.Tifo.FindAsync(id);

            if (Tifo != null)
            {


                _context.Tifo.Remove(Tifo);
                await _context.SaveChangesAsync();
                // Delete a file by using File class static method...
                var tiforoot = Path.Combine(hostingEnvironment.WebRootPath, "tifos");

                var fullpath = Path.Combine(tiforoot, Tifo.Path);
                if (System.IO.File.Exists(@fullpath))
                {
                    // Use a try block to catch IOExceptions, to
                    // handle the case of the file already being
                    // opened by another process.
                    try
                    {
                        System.IO.File.Delete(@fullpath);
                        TempData["SuccessText"] = $"File: {Tifo.Title} was deleted!";
                    }
                    catch (System.IO.IOException e)
                    {
                        TempData["FailText"] = $"File {Tifo.Title} could not be deleted";
                        Console.WriteLine(e.Message);
                       
                    }
                }



            }

            return RedirectToPage("./Index");
        }
    }
}
