using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}
