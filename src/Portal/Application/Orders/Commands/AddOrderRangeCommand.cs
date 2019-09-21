using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.Orders.Commands
{
    public class OrderRawInfo
    {

        public string CustomerName { get; set; }
        public string CityName { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }

    }
    public class AddOrderRangeCommand : IRequest<bool>
    {
        public IEnumerable<OrderRawInfo> Orders { get; set; }
    }
}
