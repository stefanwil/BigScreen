using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BigScreen.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace BigScreen.Pages.TifoAdm
{
    public class CreateModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public CreateModel(BigScreen.Data.BigScreenContext context, IHostingEnvironment environment)
        {
            _context = context;
            hostingEnvironment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tifo Tifo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Tifo.MyUploadedFile.FileName != null)
            {

                var uniqueFileName = GetUniqueFileName(Tifo.MyUploadedFile.FileName);
                var documentroot = Path.Combine(hostingEnvironment.WebRootPath, "tifos");

                var fullpath = Path.Combine(documentroot, uniqueFileName);


                Tifo.MyUploadedFile.CopyTo(new FileStream(fullpath, FileMode.Create));

                //to do : Save uniqueFileName  to your db table   

           
                Tifo.Title = Tifo.MyUploadedFile.FileName;
                Tifo.Path = uniqueFileName;
                Tifo.ContentType = Tifo.MyUploadedFile.ContentType;
                Tifo.LengthOfMedia = Tifo.MyUploadedFile.Length;

                if (ModelState.IsValid)
                {
                    _context.Add(Tifo);
                    await _context.SaveChangesAsync();
                    TempData["SuccessText"] = $"Dokument: {Tifo.Title} skapades Ok!";
                    return RedirectToPage("./Index");
                }

                TempData["FailText"] = $"Något gick fel vid skapandet av dokumentet. Försök igen";

            }
            TempData["FailText"] = $"Något gick fel vid skapandet av dokumentet. Försök igen";


            return RedirectToPage("./Index");
        }
       

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}