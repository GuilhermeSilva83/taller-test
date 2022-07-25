using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using TallerTest.Domain.Seedwork;
using TallerTest.Domain.Services;

namespace TallerTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }


        [HttpPost("guess-price")]
        public async Task< ActionResult<OperationResult>> GuessPrice (int carId, decimal price)
        {
            return await userService.GuessCarPriceAsync(carId, price);
        }
    }
}
