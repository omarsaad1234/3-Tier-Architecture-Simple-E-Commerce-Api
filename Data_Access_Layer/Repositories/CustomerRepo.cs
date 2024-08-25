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
    public class CustomerRepo:ICustomerRepo
    {
        private readonly AppDbContext _context;
        public CustomerRepo()
        {
            _context = new AppDbContext();
        }
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> GetByName(string name)
        {
            return await _context.Customers.Where(c => c.Name == name).FirstOrDefaultAsync();
        }
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public bool IsExists(int id)
        {
            return _context.Customers.Any(c => c.Id == id);
        }

        public bool IsExists(string name)
        {
            return _context.Customers.Any(c => c.Name == name);
        }
    }
}
