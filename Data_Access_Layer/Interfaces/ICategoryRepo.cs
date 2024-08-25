using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface ICategoryRepo
    {
        public Task<IEnumerable<Category>> GetAll();
        public Task<Category> GetById(int id);
        public Task<Category> GetByName(string name);
        public void Add(Category category);
        public void Update(Category category);
        public void Delete(Category category);
        public bool IsExists(int id);
        public bool IsExists(string name);
    }
}
