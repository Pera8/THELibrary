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
    public class BookService : IRepository<Book>
    {
        private readonly IRepository<Book> repositoryBook;
        private readonly IRepository<Author> repositoryAuthor;
        private readonly IRepository<Category> repositoryCategory;

        public BookService(IRepository<Book> repositoryBook, IRepository<Category> repositoryCategory, IRepository<Author> repositoryAuthor)
        {
            this.repositoryBook = repositoryBook;
            this.repositoryAuthor = repositoryAuthor;
            this.repositoryCategory = repositoryCategory;
        }
        public async Task<Book> AddAsync(BookDTO model)
        {
            if (model == null)
            {
                throw new Exception("Book can not be null");
            }
            var author = await repositoryAuthor.GetAsyncById(model.AuthorId);
            var category = await repositoryCategory.GetAsyncById(model.CategoryId);

            var bookDto = new Book()
            {
                Id = model.Id,
                Title = model.Title,
                Author = author,
                Category = category
            };
            return await repositoryBook.AddAsync(bookDto);
        }

        public Task<Book> AddAsync(Book model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            await repositoryBook.DeleteAsync(id);
           // await repositoryAuthor.Delete(1, x => x.LastName == "Pera" || x.Name == "Sima");
        }

        public Task DeleteTemp(Book result)
        {
            throw new NotImplementedException();
        }

        public async Task<DbSet<Book>> GetAllAsync()
        {
            return await repositoryBook.GetAllAsync();
        }

        public async Task<Book> GetAsyncById(int id)
        {
            return await repositoryBook.GetAsyncById(id);
        }
    }
}
