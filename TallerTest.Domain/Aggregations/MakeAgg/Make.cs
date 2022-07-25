using System;
using System.Collections.Generic;
using System.Text;

using TallerTest.Domain.Aggregations.CarAgg;
using TallerTest.Domain.Seedwork;

namespace TallerTest.Domain.Aggregations.MakeAgg
{
    public class Make : Int32Entity
    {
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}
