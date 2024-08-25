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
    public class ProductBLL
    {
        private ProductRepo _productRepo;
        private OrderItemBLL _orderItemBLL;
        public ProductBLL()
        {
            _productRepo = new ProductRepo();
            _orderItemBLL= new OrderItemBLL();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepo.GetAll();
        }
        public async Task<Product> GetById(int id)
        {
            return await _productRepo.GetById(id);
        }
        public async Task<Product> GetByName(string name)
        {
            return await _productRepo.GetByName(name);
        }
        public void Add(ProductEntity product)
        {
            Product prodToAdd = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId
            };

            _productRepo.Add(prodToAdd);
        }
        public async Task Update(ProductEntity product)
        {
            var  prodToUpdate = await GetById(product.Id);
            prodToUpdate.Name = product.Name;
            prodToUpdate.Description = product.Description;
            prodToUpdate.Price = product.Price;
            prodToUpdate.CategoryId = product.CategoryId;
            _productRepo.Update(prodToUpdate);
            var orderItems = await _orderItemBLL.GetByProductId(product.Id);
            foreach (var item in orderItems)
                await _orderItemBLL.UpdatePrice(item.Id);
        }
        public void Delete(Product product)
        {
            _productRepo.Delete(product);
        }
        public bool IsExists(int id)
        {
            return _productRepo.IsExists(id);
        }
        public bool IsExists(string name)
        {
            return _productRepo.IsExists(name);
        }
        public bool CategoryExists(int id)
        {
            return _productRepo.CategoryExists(id);
        }
    }
}
