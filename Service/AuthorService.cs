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
    public class AuthorService : IRepository<Author>
    {
        private readonly IRepository<Author> repositoryAuthor;

        public AuthorService(IRepository<Author> repositoryAuthor)
        {
            this.repositoryAuthor = repositoryAuthor;
        }
        public async Task<Author> AddAsync(AuthorDTO model)
        {
            if (model == null)
            {
                throw new Exception("Author can not be null");
            }
            var authorDTO = new Author()
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName
            };

            return await repositoryAuthor.AddAsync(authorDTO);
        }

        public Task<Author> AddAsync(Author model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            await repositoryAuthor.DeleteAsync(id);
        }

        public Task DeleteTemp(Author result)
        {
            throw new NotImplementedException();
        }

        public async Task<DbSet<Author>> GetAllAsync()
        {
            return await repositoryAuthor.GetAllAsync();
        }

        public async Task<Author> GetAsyncById(int id)
        {
            return await repositoryAuthor.GetAsyncById(id);
        }
    }
}
