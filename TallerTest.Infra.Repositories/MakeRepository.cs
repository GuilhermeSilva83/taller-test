using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TallerTest.Domain.Aggregations.CarAgg;
using TallerTest.Domain.Aggregations.MakeAgg;
using TallerTest.Domain.Seedwork;

namespace TallerTest.Infra.Repositories
{
    public class MakeRepository : Int32Repository<Make>, IMakeRepository
    {
        public MakeRepository(IUnitOfWork u) : base(u)
        {
            
        }

        public async override Task<Make> GetByIdAsync(int id)
        {
            return await GetSet()
                  .Include(w => w.Cars)
                  .FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}
