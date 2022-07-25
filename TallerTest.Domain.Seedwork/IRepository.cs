using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TallerTest.Domain.Seedwork
{
    public interface IRepository<TEntity, TId>
        where TEntity : class
    {
        void Save(TEntity entity);

        Task<List<TEntity>> ListAsync();

        void DeleteById(TId id);
        Task<TEntity> GetByIdAsync(TId id);
    }
}
