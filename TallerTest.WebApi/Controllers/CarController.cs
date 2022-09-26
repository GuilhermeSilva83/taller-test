
using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

using TallerTest.Domain.Aggregations.CarAgg;
using TallerTest.Domain.Seedwork;
using TallerTest.WebApi.Dto;

namespace TallerTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Int32CrudController<ICarRepository, Car, CarDto>
    {
        public CarController(IUnitOfWork uow, ICarRepository rep, IMapper mapper) : base(uow, rep, mapper)
        {

        }

        [HttpPost]
        [HttpPut("{id}")]
        public override OperationResult Save([FromBody] CarDto value, int id)
        {
            value.Make = null;
            return base.Save(value, id);
        }

        [HttpGet("list-by-makeId/{makeId}")]
        public async Task<IEnumerable<CarDto>> ListByMakeAsync(int makeId)
        {
            var result = await repository.ListByMakeIdAsync(makeId);
            return mapper.Map<IEnumerable<CarDto>>(result);
        }
    }
}
