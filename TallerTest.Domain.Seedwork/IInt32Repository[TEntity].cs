using System;
using System.Collections.Generic;
using System.Text;

namespace TallerTest.Domain.Seedwork
{
    public interface IInt32Repository<TEntity> : IRepository<TEntity, int>
        where TEntity : class
    {

    }
}
