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
    public class OrderRepo:IOrderRepo
    {
        private readonly AppDbContext _context;
        public OrderRepo()
        {
            _context = new AppDbContext();
        }
        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _context.Orders.Where(o=>o.Id==id).Include(o=>o.OrderItems).ThenInclude(oi=>oi.Product).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> GetByCustomerName(string name)
        {
            return await _context.Orders.Where(c => c.Customer.Name == name).Include(o=>o.OrderItems).ThenInclude(oi => oi.Product).ToListAsync();
        }
        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public bool IsExists(int id)
        {
            return _context.Orders.Any(c => c.Id == id);
        }

        public bool CustomerExists(int id)
        {
            return _context.Customers.Any(c => c.Id == id);
        }

        public bool CustomerExists(string name)
        {
            return _context.Customers.Any(c => c.Name == name);
        }
    }
}
