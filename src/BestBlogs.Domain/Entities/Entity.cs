using System;

namespace BestBlogs.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            DateRegister = DateTime.Now;
            DateUpdated = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime DateRegister { get; private set; }
        public DateTime DateUpdated { get; private set; }
    }
}