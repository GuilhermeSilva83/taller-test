using System;
using System.Collections.Generic;
using System.Text;

using TallerTest.Domain.Seedwork;

namespace TallerTest.Domain.Aggregations.CarAgg
{
    public interface ICarRepository : IInt32Repository<Car>
    {
    }
}
