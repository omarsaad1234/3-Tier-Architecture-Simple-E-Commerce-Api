﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class Customer
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public string Phone {  get; set; }
        public string Address {  get; set; }
        public List<Order> Orders {  get; set; }

    }
}
