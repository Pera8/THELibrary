using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository.IRepository;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoryService : IRepository<Category>
    {
        private readonly IRepository<Category> repositoryCategory;

        public CategoryService(IRepository<Category> repositoryCategory)
        {
            this.repositoryCategory = repositoryCategory;
        }
        public async Task<Category> AddAsync(CategoryDTO model)
        {
            if (model == null)
            {
                throw new Exception("Category can not be null");
            }
            var categoryDto = new Category()
            {
                Id = model.Id,
                CategoryName = model.CategoryName
            };
            return await repositoryCategory.AddAsync(categoryDto);
        }

        public Task<Category> AddAsync(Category model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            await repositoryCategory.DeleteAsync(id);
            //var a = await repositoryCategory.GetAllAsync();
            //var b = a.Include(x => x.BooksList);
            //var c = await b.FirstOrDefaultAsync(x => x.Id == id);
            //await repositoryCategory.DeleteTemp(c);
        }

        public async Task<DbSet<Category>> GetAllAsync()
        {
            return await repositoryCategory.GetAllAsync();
        }

        public async Task<Category> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            return await repositoryCategory.GetAsyncById(id);
        }
    }
}
