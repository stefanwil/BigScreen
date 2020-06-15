﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BigScreen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BigScreen
{
    public class GetVideoSizeModel : PageModel
    {
      

        private readonly BigScreen.Data.BigScreenContext _context;

        public GetVideoSizeModel(BigScreen.Data.BigScreenContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string Width { get; set; }
        [BindProperty]
        public string Height { get; set; }

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
        //public JsonResult OnGetList()
        //{
        //    List<string> lstString = new List<string>
        //    {
        //        "Val 1"

        //    };
        //    return new JsonResult(lstString);

        //}

        public async Task<IActionResult> OnPostSendAsync()
        //public ActionResult OnPostSend()
        {

            string sPostValue0 = "";
            string sPostValue1 = "";
            string sPostValue2 = "";



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
                        sPostValue2 = obj.Id;




                        Tifo.TifoHeight = (int)(Convert.ToInt32(obj.VideoHeight));
                        Tifo.TifoWidth = (int)(Convert.ToInt32(obj.VideoWidth));
                        Tifo.Id = Convert.ToInt32(obj.Id);
                        Tifo.Title = obj.Title;
                        Tifo.Path = obj.Path;
                        Tifo.ContentType = obj.ContentType;
                        Tifo.LengthOfMedia = (long)(Convert.ToDouble(obj.LengthOfMedia));


                        //_context.TifoPartScreen.Add(Tifodisplay);  Flyttat
                        //await _context.SaveChangesAsync();
                    }
                }
            }


            //return new JsonResult(lstString);


            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tifo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TifoExists(Tifo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            List<string> lstString = new List<string>
            {
                sPostValue0,
                sPostValue1,
                sPostValue2


            };
            return new JsonResult(lstString);
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Attach(Tifo).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TifoExists(Tifo.Id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return RedirectToPage("./Index");
        //}

        private bool TifoExists(int id)
        {
            return _context.Tifo.Any(e => e.Id == id);
        }
    }

}
