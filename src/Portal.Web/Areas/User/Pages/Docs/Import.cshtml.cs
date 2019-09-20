using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Portal.Web.Areas.User.Pages.Docs
{
    public class ImportModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public IFormFile ImportedDoc { get; set; }

        public void OnPost()
        {

        }
    }
}
