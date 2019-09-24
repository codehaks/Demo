using OfficeOpenXml;
using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Portal.Infrastrcuture
{

    public class OrderData
    {
        public string CityName { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }
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

        public IEnumerable<OrderData> GetOrders()
        {
            ExcelWorksheet worksheet = Package.Workbook.Worksheets[0];
            var rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++)
            {
                var order = new OrderData();

                var cityNameValue = worksheet.Cells[row, 1].Value;
                if (cityNameValue != null)
                {
                    var cityText = worksheet.Cells[row, 1].Value.ToString();
                    if (!(string.IsNullOrEmpty(cityText)))
                    {
                        var cityName = worksheet.Cells[row, 1].Value.ToString().Trim();
                        order.CityName = cityName;
                    }
                }

                var customerNameValue = worksheet.Cells[row, 2].Value;
                if (customerNameValue != null)
                {
                    var customerText = customerNameValue.ToString();
                    if (!(string.IsNullOrEmpty(customerText)))
                    {
                       order.CustomerName = customerText.Trim();
                    }
                }

                var productNameValue = worksheet.Cells[row, 3].Value;
                if (productNameValue != null)
                {
                    var productText = productNameValue.ToString();
                    if (!(string.IsNullOrEmpty(productText)))
                    {
                        order.ProductName = productText.Trim();
                    }
                }

                var productIdValue = worksheet.Cells[row, 4].Value;
                if (productIdValue != null)
                {
                    var productId = int.Parse(productIdValue.ToString());
                    if (!(productId<=0))
                    {
                        order.ProductId = productId;
                    }
                }

                var productPriceValue = worksheet.Cells[row, 5].Value;
                if (productPriceValue != null)
                {
                    var productPrice = int.Parse(productPriceValue.ToString());
                    if (!(productPrice <= 0))
                    {
                        order.ProductId = productPrice;
                    }
                }
                yield return order;
            }
        }


    }


}
