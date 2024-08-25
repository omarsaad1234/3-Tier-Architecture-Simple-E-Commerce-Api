using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Entities
{
    public class OrderEntity
    {
        public int Id {  get; set; }
        public int CustomerId {  get; set; }
        public DateTime CreatedDate {  get; set; }
    }
}
