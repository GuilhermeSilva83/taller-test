using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TallerTest.Domain.Seedwork;

namespace TallerTest.Domain.Services
{
    public interface IUserService
    {
        Task<OperationResult> GuessCarPriceAsync(int carId, decimal price);
    }
}
