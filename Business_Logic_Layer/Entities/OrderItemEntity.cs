﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Entities
{
    public class OrderItemEntity
    {
        public int Id { get; set; }
        public int OrderId {  get; set; }
        public int ProductId {  get; set; }
        public int Quantity {  get; set; }

    }
}
