﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
