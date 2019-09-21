using Portal.Infrastrcuture;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Portal.Test
{
    public class ImportExcelShould
    {
        [Fact]
        public void ReturnCityNames()
        {           
            using (var stream=new FileStream(@"d:\car-sales-01.xlsx",FileMode.Open))
            {
                var excelService = new ExcelImportService(stream);
                var cities = excelService.GetCityNames();

                Assert.True(cities.Count() > 0);
            }
        }
    }
}
