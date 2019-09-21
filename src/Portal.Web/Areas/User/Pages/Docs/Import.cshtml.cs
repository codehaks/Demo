using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficeOpenXml;
using Portal.Infrastrcuture;

namespace Portal.Web.Areas.User.Pages.Docs
{
    public class ImportModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public IFormFile ImportedDoc { get; set; }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            if (ImportedDoc == null || ImportedDoc.Length <= 0)
            {
                return BadRequest("Error");
            }

            if (!Path.GetExtension(ImportedDoc.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Not Support file extension");
            }

            //var list = new List<UserInfo>();

            using var stream = new MemoryStream();
            await ImportedDoc.CopyToAsync(stream, cancellationToken);
            using var excelImportService = new ExcelImportService(stream);

            var cities = excelImportService.GetCityNames();

        }
    }
}
