using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IOrderItemRepo
    {
        public Task<IEnumerable<OrderItem>> GetAll();
        public Task<OrderItem> GetById(int id);
        public Task<IEnumerable<OrderItem>> GetByOrderId(int orderId);
        public Task<IEnumerable<OrderItem>> GetByProductId(int productId);
        public void Add(OrderItem orderItem);
        public void Update(OrderItem orderItem);
        public void Delete(OrderItem orderItem);
        public bool IsExists(int id);
        public bool ProductExists(int id);
        public bool OrderExists(int id);
    }
}
