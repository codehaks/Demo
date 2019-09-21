using Portal.Infrastrcuture;
using System;
using System.IO;
using Xunit;

namespace Portal.Test
{
    public class ImportExcelShould
    {
        [Fact]
        public void ReturnCityNames()
        {
            var excelService = new ExcelImportService();
            using (var stream=new FileStream(@"d:\car-sales-01.xlsx",FileMode.Open))
            {
                var result=excelService.ExtractData(stream);

                Assert.True(result.Cities.Count > 0);
            }
        }
    }
}
