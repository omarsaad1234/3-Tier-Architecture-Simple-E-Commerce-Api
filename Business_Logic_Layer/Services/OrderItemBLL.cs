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
    public class OrderItemBLL
    {
        private OrderItemRepo _orderItemRepo;
        private ProductRepo _productRepo;
        private OrderRepo _orderRepo;
        public OrderItemBLL()
        {
            _orderItemRepo = new OrderItemRepo();
            _productRepo= new ProductRepo();
            _orderRepo = new OrderRepo();
        }
        public async Task<IEnumerable<OrderItem>> GetAll()
        {
            return await _orderItemRepo.GetAll();
        }
        public async Task<IEnumerable<OrderItem>> GetByProductId(int productId)
        {
            return await _orderItemRepo.GetByProductId(productId);
        }
        public async Task<IEnumerable<OrderItem>> GetByOrderId(int orderId)
        {
            return await _orderItemRepo.GetByOrderId(orderId);
        }
        public async Task<OrderItem> GetById(int id)
        {
            return await _orderItemRepo.GetById(id);
        }
        public async Task Add(OrderItemEntity orderItem)
        {
            Product prod = await _productRepo.GetById(orderItem.ProductId);
            OrderItem orderItemToAdd = new OrderItem
            {
                ProductId = orderItem.ProductId,
                OrderId = orderItem.OrderId,
                Quantity = orderItem.Quantity,
                Subtotal = orderItem.Quantity * prod.Price
            };
            Order order = await _orderRepo.GetById(orderItem.OrderId);
            order.Cost += orderItemToAdd.Subtotal;
            _orderRepo.Update(order);
            _orderItemRepo.Add(orderItemToAdd);
        }
        public async Task Update(OrderItemEntity orderItem)
        {
            Product prod = await _productRepo.GetById(orderItem.ProductId);
            Order order = await _orderRepo.GetById(orderItem.OrderId);
            var orderItemToUpdate = await GetById(orderItem.Id);
            order.Cost -= orderItemToUpdate.Subtotal;
            orderItemToUpdate.ProductId = orderItem.ProductId;
            orderItemToUpdate.OrderId = orderItem.OrderId;
            orderItemToUpdate.Quantity = orderItem.Quantity;
            orderItemToUpdate.Subtotal = orderItem.Quantity * prod.Price;
            order.Cost += orderItemToUpdate.Subtotal;
            _orderRepo.Update(order);
            _orderItemRepo.Update(orderItemToUpdate);
        }
        public async Task UpdatePrice(int id)
        {

            OrderItem orderitem = await GetById(id);
            Order order = await _orderRepo.GetById(orderitem.OrderId);
            order.Cost -= orderitem.Subtotal;
            Product prod = await _productRepo.GetById(orderitem.ProductId);
            orderitem.Subtotal = orderitem.Quantity * prod.Price;
            order.Cost += orderitem.Subtotal;
            _orderRepo.Update(order);
            _orderItemRepo.Update(orderitem);
        }
        public async Task Delete(OrderItem orderItem)
        {
            Order order = await _orderRepo.GetById(orderItem.OrderId);
            order.Cost -= orderItem.Subtotal;
            _orderRepo.Update(order);
            _orderItemRepo.Delete(orderItem);
        }
        public bool IsExists(int id)
        {
            return _orderItemRepo.IsExists(id);
        }
        public bool OrderExists(int id)
        {
            return _orderItemRepo.OrderExists(id);
        }
        public bool ProductExists(int id)
        {
            return _orderItemRepo.ProductExists(id);
        }
    }
}
