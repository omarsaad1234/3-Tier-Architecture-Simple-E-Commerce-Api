using Data_Access_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId {  get; set; }
        public int ProductId {  get; set; }
        public int Quantity {  get; set; }
        public decimal Subtotal { get; set; }
        [JsonIgnore]
        public Order Order {  get; set; }
        public Product Product {  get; set; }


    }
}
