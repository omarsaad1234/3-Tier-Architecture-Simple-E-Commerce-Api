using Data_Access_Layer.Data;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class OrderItemRepo:IOrderItemRepo
    {
        private readonly AppDbContext _context;
        public OrderItemRepo()
        {
            _context = new AppDbContext();
        }
        public async Task<IEnumerable<OrderItem>> GetAll()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task<OrderItem> GetById(int id)
        {
            return await _context.OrderItems.FindAsync(id);
        }

        public async Task<IEnumerable<OrderItem>> GetByOrderId(int orderId)
        {
            return await _context.OrderItems.Where(c => c.OrderId == orderId).ToListAsync();
        }
        public void Add(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();
        }

        public void Update(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
            _context.SaveChanges();
        }

        public void Delete(OrderItem orderItem)
        {
            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges();
        }

        public bool IsExists(int id)
        {
            return _context.OrderItems.Any(c => c.Id == id);
        }

        public bool ProductExists(int id)
        {
            return _context.Products.Any(c => c.Id == id);
        }

        public bool OrderExists(int id)
        {
            return _context.Orders.Any(c => c.Id == id);
        }

        public async Task<IEnumerable<OrderItem>> GetByProductId(int productId)
        {
            return await _context.OrderItems.Where(O => O.ProductId == productId).ToListAsync();
        }
    }
}
