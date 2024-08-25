using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class Product
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public decimal Price { get;set; }
        public string? Description { get; set; }
        public int CategoryId {  get; set; }
        public Category Category {  get; set; }
        [JsonIgnore]
        public List<OrderItem> OrderItems {  get; set; }
    }
}
