using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class CookieModel : PageModel
    {
        [BindProperty, Display(Name = "Pink mode")]
        public bool PinkMode { get; set; }

        public void OnGet()
        {
            PinkMode = Request.Cookies["PinkMode"] == "True";
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string value = PinkMode.ToString();

            Response.Cookies.Append("PinkMode", value);

            return RedirectToPage();
        }
    }
}
