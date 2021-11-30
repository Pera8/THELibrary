using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class Repository<TModel> : IRepository<TModel> where TModel :class, IBaseModel
    {
        private readonly AppDbContext appDbContext;

        public Repository (AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<TModel> AddAsync(TModel model)
        {
            if (model == null)
            {
                throw new Exception("Entity can not be null");
            }

             await appDbContext.AddAsync(model);
             await appDbContext.SaveChangesAsync();
            return model;
        }

        public async Task DeleteAsync(int id)
        {
             var result= await appDbContext.Set<TModel>().FirstOrDefaultAsync(e=>e.Id==id);

            if (result != null)
            {
                appDbContext.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteTemp(TModel result)
        {
            appDbContext.Remove(result);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<DbSet<TModel>> GetAllAsync()
        {
            return  appDbContext.Set<TModel>();
        }

        public async Task<TModel> GetAsyncById(int id)
        {
            return await appDbContext.Set<TModel>().FirstOrDefaultAsync(e => e.Id == id);
        }

        //public async Task Delete (int id, Expression<Func<TModel, bool>> criteria) 
        //{
        //    //IEnumerable<TModel> records = await appDbContext.Set<TModel>();

        //    //foreach (TModel record in records)
        //    //{
        //    //    appDbContext.Remove(record);
        //    //    await appDbContext.SaveChangesAsync();
        //    //}
        //    var item = await GetAsyncById(id);
        //    item.IsDeleted = true;
        //    appDbContext.Entry<TModel>(item).State = EntityState.Modified;
        //    await appDbContext.SaveChangesAsync();
        //}

    }
}
