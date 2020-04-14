using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Domain.Contracts.Repositories;
using Demo.Domain.Entities;
using Demo.Infrastucture.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastucture.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> 
    where TEntity : BaseEntity
    
    {
        protected readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context) : base()
           => _context = context;

        public virtual async Task<TEntity> Add(TEntity entity)
        {
           await _context.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
            => await _context.Set<TEntity>().ToListAsync();

        public virtual async Task<TEntity> GetById(Guid id)
             => await _context.Set<TEntity>().FirstOrDefaultAsync();


        public virtual async Task Remove(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        // public void SaveChanges()
        //    => _context.SaveChanges();

        public  async Task Update(TEntity entity)
        {
               _context.Entry(entity).State = EntityState.Modified;
               //_context.Set<TEntity>().Attach(entity);
               await _context.SaveChangesAsync();
        }
    }
}