﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Entities
{
    public class ProductEntity
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public decimal Price {  get; set; }
        public string? Description { get; set; }
        public int CategoryId {  get; set; }
    }
}
