using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class ErrorsModel : PageModel
    {
        public int ErrorCode { get; set; }

        public void OnGet(int errorCode)
        {
            ErrorCode = errorCode;
        }
    }
}
