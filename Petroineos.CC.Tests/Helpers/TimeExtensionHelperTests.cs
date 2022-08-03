using NUnit.Framework;
using Petroineos.CC.Service.Helpers;
using System.Collections.Generic;

namespace Petroineos.CC.Tests.Helpers
{
    public class TimeExtensionHelperTests
    {
        [Test]
        public void Given_A_Period_When_I_Call_GetLocalTime_Should_Return_A_Valid_Time()
        {
            int period = 1;
            var result = period.ToLocalTime();
            Assert.AreEqual("23:00", result);
        }

        [Test]
        public void Given_An_Invalid_Period_When_I_Call_GetLocalTime_Should_Throw_An_Exception()
        {
            int period = -1;
            Assert.Throws<KeyNotFoundException>(()=>period.ToLocalTime());
        }

        [Test]
        public void Given_Period_4_When_I_Call_GetLocalTime_Should_Return_Time_As_0200_Time()
        {
            int period = 4;
            var result = period.ToLocalTime();
            Assert.AreEqual("02:00", result);
        }

    }
}
