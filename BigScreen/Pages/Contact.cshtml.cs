using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigScreen.Pages
{
    public class ContactModel : PageModel
    {
   
            public string Message { get; set; }

            public void OnGet()
            {
                Message = "Your contact page.";
            }

            public void OnGetMessage()
            {
                Message = "My Custom Message";
            }
      
    }
}