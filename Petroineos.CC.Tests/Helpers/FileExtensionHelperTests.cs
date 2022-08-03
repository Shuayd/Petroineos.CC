using NUnit.Framework;
using Petroineos.CC.Service.Helpers;
using System;

namespace Petroineos.CC.Tests.Helpers
{
    public class FileExtensionHelperTests
    {
        [Test]
        public void Given_A_Position_And_Date_When_I_Call_GetFileName_Should_Return_A_Valid_Filename()
        {
            int positon = 1;
            DateTime date = new DateTime(2022, 08, 01);
            var result = FileExtensionHelper.GetFileName(positon, date);
            Assert.AreEqual("1_20220801_0000.csv", result);
        }
    }
}
