﻿using Jazani.Domain.Cores.Repositories;
using Jazani.Infastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infastructure.Cores.Persistences
{
    public  abstract class CrudRepository<T, ID> : ICrudRepository<T, ID> where T : class
    {
        public readonly ApplicationDbContext _dbContext;

        public CrudRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<IReadOnlyList<T>> FindAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T?> FindByIdAsync(ID id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async  Task<T> SaveAsync(T entity)
        {
            EntityState state = _dbContext.Entry(entity).State;
            _ = state switch
            {
                EntityState.Detached => _dbContext.Set<T>().Add(entity),
                EntityState.Modified => _dbContext.Set<T>().Update(entity)
            };

            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
