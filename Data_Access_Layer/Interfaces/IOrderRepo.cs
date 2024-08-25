using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IOrderRepo
    {
        public Task<IEnumerable<Order>> GetAll();
        public Task<Order> GetById(int id);
        public Task<IEnumerable<Order>> GetByCustomerName(string name);
        public void Add(Order order);
        public void Update(Order order);
        public void Delete(Order order);
        public bool IsExists(int id);
        public bool CustomerExists(int id);
        public bool CustomerExists(string name);
    }
}
