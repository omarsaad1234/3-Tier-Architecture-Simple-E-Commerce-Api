using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class Order
    {
        public int Id {  get; set; }
        public int CustomerId {  get; set; }
        public DateTime CreatedDate {  get; set; }
        public decimal Cost {  get; set; }
        public Customer Customer {  get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
