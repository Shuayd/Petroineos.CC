using Moq;
using NUnit.Framework;
using Petroineos.CC.Service;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Petroineos.CC.Tests
{

    public class PowerPositionServiceTests
    {
        private PowerPositionService _service;
        private Mock<IPowerService> _powerService;

        [SetUp]
        public void SetUp()
        {
            _powerService = new Mock<IPowerService>();

            GeneratePowerTradeMocks();

            _service = new PowerPositionService(_powerService.Object);
        }

        [Test]
        public void When_I_Call_GetPowerPosition_Should_ReturnItems()
        {
            var date = new DateTime(2022,08,03);
            var result = _service.GetPowerPosition(date);

            _powerService.Verify(x => x.GetTrades(It.IsAny<DateTime>()), Times.Once);
            Assert.IsTrue(result.Count() != 0);
        }

        [Test]
        public void When_I_Call_GetPowerPosition_Should_ReturnItems_In_Order()
        {
            var date = DateTime.Now;
            var result = _service.GetPowerPosition(date);

            _powerService.Verify(x => x.GetTrades(It.IsAny<DateTime>()), Times.Once);
            Assert.That(result, Is.Ordered.By("Position"));
        }

        [Test]
        public void When_I_Call_GetPowerPosition_Should_ReturnItems_With_Start_Position_As_1_With_LocalTime_2300()
        {
            var date = DateTime.Now;
            var result = _service.GetPowerPosition(date);
            var firstItem = result.FirstOrDefault();

            _powerService.Verify(x => x.GetTrades(It.IsAny<DateTime>()), Times.Once);

            Assert.AreEqual(firstItem.LocalTime, "23:00");
            Assert.AreEqual(firstItem.Volume, 0);
            Assert.AreEqual(firstItem.Position, 1);
        }

        [Test]
        public void When_I_Call_Invalid_GetPowerPosition_Should_Throw_Exception()
        {
            _powerService.Setup(x => x.GetTrades(It.IsAny<DateTime>())).Throws(new Exception());

            var date = DateTime.Now;

            Assert.Throws<Exception>(() => _service.GetPowerPosition(date));

            _powerService.Verify(x => x.GetTrades(It.IsAny<DateTime>()), Times.Once);
        }

        private void GeneratePowerTradeMocks(int numOfDataItems = 5)
        {
            var powerTrades = new List<PowerTrade>();

            for (var i = 0; i < numOfDataItems; i++)
            {
                var powerTrade = PowerTrade.Create(new DateTime(2022, 08, 03), i);
                powerTrades.Add(powerTrade);
            }
            _powerService.Setup(x => x.GetTrades(It.IsAny<DateTime>())).Returns(powerTrades);
        }
    }
}
