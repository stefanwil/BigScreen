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
using Newtonsoft.Json;

namespace BigScreen.Pages.TifoAdm
{
    public class CreateModel : PageModel
    {
        private readonly BigScreen.Data.BigScreenContext _context;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly Tifo Tifotemp = new Tifo();

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


                Tifo.Title = Tifo.Title;
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
            //return Page();

        }

        public JsonResult OnGetList()
        {
            if(Tifo==null) return new JsonResult("");
            if (Tifo.Path == null) Tifo.Path = "";
            return new JsonResult(Tifo.Path);

        }

        public async Task<IActionResult> OnPostSendAsync()
        //public ActionResult OnPostSend()
        {

            string sPostValue0 = "";
            string sPostValue1 = "";



            MemoryStream stream = new MemoryStream();
            Request.Body.CopyTo(stream);
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream))
            {
                string requestBody = reader.ReadToEnd();
                if (requestBody.Length > 0)
                {
                    var obj = JsonConvert.DeserializeObject<Videoinfo>(requestBody);
                    if (obj != null)
                    {

                        sPostValue0 = obj.VideoWidth;
                        sPostValue1 = obj.VideoHeight;



                        Tifo.TifoHeight = (int)(Convert.ToDecimal(obj.VideoHeight));
                        Tifo.TifoWidth = (int)(Convert.ToDecimal(obj.VideoWidth));

                        Tifo.Title = Tifotemp.Title;
                        Tifo.Path = Tifotemp.Path;
                        Tifo.ContentType = Tifotemp.ContentType;
                        Tifo.LengthOfMedia = Tifotemp.LengthOfMedia;



                    }
                }
            }


            //return new JsonResult(lstString);

            if (ModelState.IsValid)
            {

                _context.Add(Tifo);
                await _context.SaveChangesAsync();
                TempData["SuccessText"] = $"Dokument: {Tifo.Title} skapades Ok!";
                //return RedirectToPage("./Index");
            }

            TempData["FailText"] = $"Något gick fel vid skapandet av dokumentet. Försök igen";


            TempData["FailText"] = $"Något gick fel vid skapandet av dokumentet. Försök igen";


            //return RedirectToPage("./Index");
            //return Page();
       

        List<string> lstString = new List<string>
            {
                sPostValue0,
                sPostValue1,


            };
            return new JsonResult(lstString);
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