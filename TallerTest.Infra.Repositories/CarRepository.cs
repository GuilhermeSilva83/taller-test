using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TallerTest.Domain.Aggregations.CarAgg;
using TallerTest.Domain.Seedwork;

namespace TallerTest.Infra.Repositories
{
    public class CarRepository : Int32Repository<Car>, ICarRepository
    {
        public CarRepository(IUnitOfWork u) : base(u)
        {

        }

        public override async Task<List<Car>> ListAsync()
        {
            return await GetSet()
                    .Include(x => x.Make)
                    .ToListAsync();
        }

        public override async Task<Car> GetByIdAsync(int id)
        {
            return await GetSet()
                    .Include( x => x.Make)
                    .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<Car>> ListByMakeIdAsync(int makeId)
        {
            return await GetSet()
                   .Include(x => x.Make)
                   .Where(w => w.MakeId == makeId || makeId == 0)
                   .ToListAsync();
        }
    }
}
