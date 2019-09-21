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


        public IList<string> GetCitieNames()
        {

            var result = new List<string>();

            ExcelWorksheet worksheet = Package.Workbook.Worksheets[0];
            var rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++)
            {
                result.Add(worksheet.Cells[row, 1].Value.ToString().Trim()
                );
            }

            return result;
        }


    }
}
