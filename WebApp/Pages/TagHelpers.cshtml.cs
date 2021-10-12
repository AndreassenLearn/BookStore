using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class TagHelpersModel : PageModel
    {
        [Display(Name = "Tesla Model Y")]
        public string ImageUrl { get; set; }

        public void OnGet()
        {
            ImageUrl = "~/images/tesla_model_y.jpg";
        }
    }
}
