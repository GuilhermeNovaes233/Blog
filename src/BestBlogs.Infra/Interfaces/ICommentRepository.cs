using BestBlogs.Domain.Entities;
using System;

namespace BestBlogs.Infra.Interfaces
{
    public interface ICommentRepository : IRepositoryBase<Comment>
    {
    }
}