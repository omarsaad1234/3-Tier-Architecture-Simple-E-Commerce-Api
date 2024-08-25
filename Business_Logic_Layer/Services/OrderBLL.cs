using Business_Logic_Layer.Entities;
using Data_Access_Layer.Models;
using Data_Access_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class OrderBLL
    {
        private OrderRepo _orderRepo;
        public OrderBLL()
        {
            _orderRepo = new OrderRepo();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _orderRepo.GetAll();
        }
        public async Task<Order> GetById(int id)
        {
            return await _orderRepo.GetById(id);
        }
        public async Task<IEnumerable<Order>> GetByCustomerName(string name)
        {
            return await _orderRepo.GetByCustomerName(name);
        }
        public void Add(OrderEntity order)
        {
            Order orderToAdd = new Order
            {
                CustomerId = order.CustomerId,
                CreatedDate = order.CreatedDate
            };
            _orderRepo.Add(orderToAdd);
        }
        public async Task Update(OrderEntity order)
        {
            var orderToUpdate = await GetById(order.Id);
            orderToUpdate.CustomerId = order.CustomerId;
            orderToUpdate.CreatedDate = order.CreatedDate;
            _orderRepo.Update(orderToUpdate);
        }
        public void Delete(Order Order)
        {
            _orderRepo.Delete(Order);
        }
        public bool IsExists(int id)
        {
            return _orderRepo.IsExists(id);
        }
        public bool CustomerExists(int id)
        {
            return _orderRepo.CustomerExists(id);
        }
        public bool CustomerExists(string name)
        {
            return _orderRepo.CustomerExists(name);
        }
    }
}
