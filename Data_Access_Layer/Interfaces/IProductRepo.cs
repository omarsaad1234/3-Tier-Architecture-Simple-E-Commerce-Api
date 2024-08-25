using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IProductRepo
    {
        public Task<IEnumerable<Product>> GetAll();
        public Task<Product> GetById(int id);
        public Task<Product> GetByName(string name);
        public void Add(Product product);
        public void Update(Product product);
        public void Delete(Product product);
        public bool IsExists(int id);
        public bool CategoryExists(int id);
        public bool IsExists(string name);
    }
}
