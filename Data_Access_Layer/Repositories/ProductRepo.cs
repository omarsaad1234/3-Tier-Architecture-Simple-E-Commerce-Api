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
    public class ProductRepo:IProductRepo
    {
        private readonly AppDbContext _context;
        public ProductRepo()
        {
            _context = new AppDbContext();
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.OrderBy(x => x.Name).Include(p=>p.Category).ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.Include(p=>p.Category).Where(p=>p.Id==id).FirstOrDefaultAsync();
        }

        public async Task<Product> GetByName(string name)
        {
            return await _context.Products.Include(p => p.Category).Where(c => c.Name == name).FirstOrDefaultAsync();
        }
        public void Add(Product Product)
        {
            _context.Products.Add(Product);
            _context.SaveChanges();
        }

        public void Update(Product Product)
        {
            _context.Products.Update(Product);
            _context.SaveChanges();
        }

        public void Delete(Product Product)
        {
            _context.Products.Remove(Product);
            _context.SaveChanges();
        }

        public bool IsExists(int id)
        {
            return _context.Products.Any(c => c.Id == id);
        }

        public bool IsExists(string name)
        {
            return _context.Products.Any(c => c.Name == name);
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }
    }
}
