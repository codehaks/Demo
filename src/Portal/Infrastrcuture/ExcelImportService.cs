using OfficeOpenXml;
using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Portal.Infrastrcuture
{
    public class ExcelDataModel
    {
        public IList<City> Cities { get; set; }
        public IList<Order> Orders { get; set; }
    }

    public class ExcelImportService : IDisposable
    {
        private ExcelPackage Package;

        public ExcelImportService(Stream stream)
        {
            Package = new ExcelPackage(stream);
        }

        #region Dispose


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Package != null)
                {
                    Package.Dispose();
                    Package = null;
                }
            }

        }
        #endregion


        public IEnumerable<string> GetCityNames()
        {

            ExcelWorksheet worksheet = Package.Workbook.Worksheets[0];
            var rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++)
            {
                var cellValue = worksheet.Cells[row, 1].Value;
                if (cellValue != null)
                {
                    var cityText = worksheet.Cells[row, 1].Value.ToString();
                    if (!(string.IsNullOrEmpty(cityText)))
                    {
                        var cityName = worksheet.Cells[row, 1].Value.ToString().Trim();
                        yield return cityName;
                    }
                }
            }


        }


    }
}
