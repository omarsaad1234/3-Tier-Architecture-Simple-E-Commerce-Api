using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface ICustomerRepo
    {
        public Task<IEnumerable<Customer>> GetAll();
        public Task<Customer> GetById(int id);
        public Task<Customer> GetByName(string name);
        public void Add(Customer customer);
        public void Update(Customer customer);
        public void Delete(Customer customer);
        public bool IsExists(int id);
        public bool IsExists(string name);
    }
}
