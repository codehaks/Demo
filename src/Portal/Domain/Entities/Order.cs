using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int CustomerName { get; set; }

        public Product Product { get; set; }
        public City City { get; set; }



    }
}
