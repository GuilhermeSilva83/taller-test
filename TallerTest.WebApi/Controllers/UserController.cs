using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using TallerTest.Domain.Seedwork;
using TallerTest.Domain.Services;
using TallerTest.WebApi.Dto;

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
        public async Task< ActionResult<OperationResult>> GuessPrice (GuessPriceDto guess)
        {
            return await userService.GuessCarPriceAsync(guess.ModelId, guess.Price);
        }
    }
}
