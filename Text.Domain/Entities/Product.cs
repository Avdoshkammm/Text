﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text.Domain.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public decimal Cost { get; set; }
    }
}
