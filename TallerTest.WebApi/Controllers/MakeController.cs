
using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using TallerTest.Domain.Aggregations.CarAgg;
using TallerTest.Domain.Aggregations.MakeAgg;
using TallerTest.Domain.Seedwork;
using TallerTest.WebApi.Dto;

namespace TallerTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakeController : Int32CrudController<IMakeRepository, Make, MakeDto>
    {
        public MakeController(IUnitOfWork uow, IMakeRepository rep, IMapper mapper) : base(uow, rep, mapper)
        {

        }

    }
}
