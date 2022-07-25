using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TallerTest.Domain.Seedwork;

namespace TallerTest.Domain.Aggregations.CarAgg
{
    public interface ICarRepository : IInt32Repository<Car>
    {
        Task<IEnumerable<Car>> ListByMakeIdAsync(int makeId);
    }
}
