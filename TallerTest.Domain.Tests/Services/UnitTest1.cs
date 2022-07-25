using NUnit.Framework;

using TallerTest.Domain.Services;
using Moq;
using TallerTest.Domain.Aggregations.CarAgg;
using System.Threading.Tasks;

namespace TallerTest.Domain.Tests.Services
{
    public class UserService_UT
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Case_01_Success_Price_Higher()
        {
            // arrange

            var mock = new Mock<ICarRepository>();
            mock.Setup(c => c.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Car()
            {
                Price = 15000
            });
            
            var service = new UserService(mock.Object);

            // act

            var result = await service.GuessCarPriceAsync(1, 20000);



            Assert.IsTrue(result.Success, "must be true");
        }

        [Test]
        public async Task Case_02_Fail_Price_Higher()
        {
            // arrange

            var mock = new Mock<ICarRepository>();
            mock.Setup(c => c.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Car()
            {
                Price = 15000
            });

            var service = new UserService(mock.Object);

            // act

            var result = await service.GuessCarPriceAsync(1, 20001);



            Assert.IsFalse(result.Success, "must be false");
        }

        [Test]
        public async Task Case_03_Success_PriceLower()
        {
            // arrange

            var mock = new Mock<ICarRepository>();
            mock.Setup(c => c.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Car()
            {
                Price = 15000
            });

            var service = new UserService(mock.Object);

            // act

            var result = await service.GuessCarPriceAsync(1, 10000);



            Assert.IsTrue(result.Success, "must be true");
        }

        [Test]
        public async Task Case_04_Fail_PriceLower()
        {
            // arrange

            var mock = new Mock<ICarRepository>();
            mock.Setup(c => c.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Car()
            {
                Price = 15000
            });

            var service = new UserService(mock.Object);

            // act

            var result = await service.GuessCarPriceAsync(1, 9999);



            Assert.False(result.Success, "must be false");
        }
    }
}