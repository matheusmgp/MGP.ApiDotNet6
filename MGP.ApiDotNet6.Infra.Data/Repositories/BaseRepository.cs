

using MGP.ApiDotNet6.Domain.Entities;
using MGP.ApiDotNet6.Domain.Repositories;
using MGP.ApiDotNet6.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MGP.ApiDotNet6.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {       
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _dbContext.Set<TEntity>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
           return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var found = await GetByIdAsync(entity.Id);
            _dbContext.Set<TEntity>().Update(found);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
