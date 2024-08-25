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
    public class CategoryBLL
    {
        private CategoryRepo _categoryRepo;
        public CategoryBLL()
        {
            _categoryRepo = new CategoryRepo();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepo.GetAll();
        }
        public async Task<Category> GetById(int id)
        {
            return await _categoryRepo.GetById(id);
        }
        public async Task<Category> GetByName(string name)
        {
            return await _categoryRepo.GetByName(name);
        }
        public void Add(CategoryEntity category)
        {
            Category categoryToAdd = new Category
            {
                Name = category.Name,
                Description = category.Description
            };
            _categoryRepo.Add(categoryToAdd);
        }
        public async Task Update(CategoryEntity category)
        {
            var categoryToUpdate = await GetById(category.Id);
            categoryToUpdate.Name=category.Name;
            categoryToUpdate.Description = category.Description;
            _categoryRepo.Update(categoryToUpdate);
        }
        public void Delete(Category Category)
        {
            _categoryRepo.Delete(Category);
        }
        public bool IsExists(int id)
        {
            return _categoryRepo.IsExists(id);
        }
        public bool IsExists(string name)
        {
            return _categoryRepo.IsExists(name);
        }
    }
}
