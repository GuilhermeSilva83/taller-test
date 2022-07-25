using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using TallerTest.Domain.Aggregations.MakeAgg;
using TallerTest.Domain.Seedwork;

namespace TallerTest.Domain.Aggregations.CarAgg
{
    public class Car : Int32Entity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int MakeId { get; set; }
        public short Year { get; set; }
        public short Doors { get; set; }
        public decimal Price { get; set; }

        [ForeignKey(nameof(MakeId))]
        public Make Make { get; set; }
    }
}
