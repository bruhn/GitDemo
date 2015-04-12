using System;
using GitDemo;
using Moq;
using NUnit.Framework;

namespace GitDemoTest
{
    [TestFixture]
    public class RestaurantReservationServiceTest
    {
        private Mock<ITableScheduleService> _tableScheduleService;

        private RestaurantReservationService _sut;

        [SetUp]
        public void SetUpTest()
        {
            _tableScheduleService = new Mock<ITableScheduleService>();

            _sut = new RestaurantReservationService(_tableScheduleService.Object);
        }

        [Test]
        public void CanCreateReservation()
        {
            //Arrange
            const int numberOfPersons = 4;
            var startTime = new DateTime(2015, 4, 13, 18, 0, 0);

            _tableScheduleService.Setup(x => x.CheckAvailability(numberOfPersons, startTime)).Returns(true);

            //Act
            var result = _sut.CreateReservation(numberOfPersons, startTime);

            //Assert
            Assert.True(result.Success);
        }

        [Test]
        public void CanBookTableWhenTableIsAvailable()
        {
            //Arrange
            const int numberOfPersons = 4;
            var startTime = new DateTime(2015, 4, 13, 18, 0, 0);

            _tableScheduleService.Setup(x => x.CheckAvailability(numberOfPersons, startTime)).Returns(true);

            //Act
            _sut.CreateReservation(numberOfPersons, startTime);

            //Assert
            _tableScheduleService.Verify(x => x.ExecuteBooking(numberOfPersons, startTime), Times.Once);
        }
    }
}
