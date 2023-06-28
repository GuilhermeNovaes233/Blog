using System;

namespace BestBlogs.Infra.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> AddAsync(TEntity obj);
        Task<List<TEntity>> AddRangeAsync(List<TEntity> obj);
        TEntity GetById(Guid id);
        Task<TEntity> GetByPostIdAsync(Guid postId);
        Task<TEntity> GetByIdAsync(Guid id);
        IEnumerable<TEntity> GetAllAsync();
        void Update(TEntity obj);
        Task UpdateAsync(TEntity obj);
        void Remove(TEntity obj);
        Task RemoveAsync(TEntity obj);
        void Dispose();
    }
}