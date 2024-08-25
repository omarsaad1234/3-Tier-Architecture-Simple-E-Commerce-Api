﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class Category
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public List<Product> Products {  get; set; }
    }
}
