using System;
using System.Data;

namespace TallerTest.Domain.Seedwork
{
    public abstract class Entity<TId> : IEntity<TId>
    {
        public abstract TId Id { get; set; }
        public abstract bool IsTransient();
    }
}
