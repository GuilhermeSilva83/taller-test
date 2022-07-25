using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TallerTest.Domain.Aggregations.CarAgg;
using TallerTest.Domain.Seedwork;

namespace TallerTest.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly ICarRepository carRepository;

        public UserService(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public async Task<OperationResult> GuessCarPriceAsync(int carId, decimal price)      
        {

            var car = await carRepository.GetByIdAsync(carId);

            var rangeUp = price + 5000;
            var rangeDown = price - 5000;

            
            if (rangeUp >= car.Price & car.Price >= rangeDown)
            {
                return OperationResult.Ok("Great Job!");
            }
            else
            {
                return OperationResult.Fail("Failed!");
            }

        }
    }
}
