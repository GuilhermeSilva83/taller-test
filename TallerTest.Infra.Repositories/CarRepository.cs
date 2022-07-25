using System;
using System.Collections.Generic;
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
                    .ToListAsync();
        }

        public override async Task<Car> GetByIdAsync(int id)
        {
            return await GetSet()
                    .FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}
