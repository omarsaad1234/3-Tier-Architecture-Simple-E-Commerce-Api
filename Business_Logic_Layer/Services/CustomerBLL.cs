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
    public class CustomerBLL
    {
        private CustomerRepo _customerRepo;
        public CustomerBLL()
        {
            _customerRepo = new CustomerRepo();
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _customerRepo.GetAll();
        }
        public async Task<Customer> GetById(int id)
        {
            return await _customerRepo.GetById(id);
        }
        public async Task<Customer> GetByName(string name)
        {
            return await _customerRepo.GetByName(name);
        }
        public void Add(CustomerEntity customer)
        {
            Customer cust = new Customer
            {
                Name = customer.Name,
                Phone = customer.Phone,
                Address = customer.Address
            };
            _customerRepo.Add(cust);
        }
        public async Task Update(CustomerEntity customer)
        {
            var cust = await GetById(customer.Id);
            cust.Name = customer.Name;
            cust.Phone = customer.Phone;
            cust.Address = customer.Address;
            _customerRepo.Update(cust);
        }
        public void Delete(Customer customer)
        {
            _customerRepo.Delete(customer);
        }
        public bool IsExists(int id)
        {
            return _customerRepo.IsExists(id);
        }
        public bool IsExists(string name)
        {
            return _customerRepo.IsExists(name);
        }
    }
}
