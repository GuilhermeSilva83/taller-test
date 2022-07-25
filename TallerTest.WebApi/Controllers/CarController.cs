
using AutoMapper;

using Microsoft.AspNetCore.Mvc;

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
    }
}
