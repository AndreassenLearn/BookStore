using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class SessionModel : PageModel
    {
        const string NAME = "NAME";
        const string AGE = "AGE";

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public int Age { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            HttpContext.Session.SetString(NAME, Name);
            HttpContext.Session.SetInt32(AGE, Age);

            return RedirectToPage();
        }
    }
}
