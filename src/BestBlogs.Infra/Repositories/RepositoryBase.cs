﻿using BestBlogs.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BestBlogs.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected DbContext _db;
        protected DbSet<TEntity> _dbSet;

        public RepositoryBase(DbContext context)
        {
            _db = context;
            _dbSet = _db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            _dbSet.Add(obj);
        }

        public async Task<TEntity> AddAsync(TEntity obj)
        {
            await _dbSet.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> obj)
        {
            await _dbSet.AddRangeAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public TEntity GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        
        public virtual async Task<TEntity> GetByPostIdAsync(Guid postId)
        {
            return await _dbSet.FindAsync(postId);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Update(TEntity obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
        }

        public async Task UpdateAsync(TEntity obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public void Remove(TEntity obj)
        {
            _dbSet.Remove(obj);
        }

        public async Task RemoveAsync(TEntity obj)
        {
            _dbSet.Remove(obj);
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(true);
        }
    }
}