using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Petroineos.CC.Service;
using Petroineos.CC.Service.Configuration;
using Petroineos.CC.Service.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Petroineos.CC.Tests
{
    public class ReportServiceTests
    {
        private ReportService _service;
        private Mock<IOptions<AppSettings>> _settings;

        [SetUp]
        public void SetUp()
        {
            _settings = new Mock<IOptions<AppSettings>>();
            _settings.Setup(x => x.Value).Returns(new AppSettings { CSVFilePath = GetDirectory() });
            _service = new ReportService(_settings.Object);
        }


        [Test]
        public void When_I_Call_ExportToCSV_Should_Export_Data()
        {
            var date = new DateTime(2022, 08, 03);
            var positions = GetPowerPositions();

            _service.ExportToCSV(positions, date);

            Assert.NotNull(File.ReadAllBytes(GetDirectory() + "\\2690_20220803_0000.csv"));
        }

        private string GetDirectory()
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            return projectDirectory + "\\Temp";
        }

        private List<PowerPosition> GetPowerPositions()
        {
            return new List<PowerPosition>() {
                new PowerPosition { Position = 1, LocalTime = "23:00", Volume = 150 },
                new PowerPosition { Position = 2, LocalTime = "00:00", Volume = 150 },
                new PowerPosition { Position = 3, LocalTime = "01:00", Volume = 150 },
                new PowerPosition { Position = 4, LocalTime = "02:00", Volume = 150 },
                new PowerPosition { Position = 5, LocalTime = "03:00", Volume = 150 },
                new PowerPosition { Position = 6, LocalTime = "04:00", Volume = 150 },
                new PowerPosition { Position = 7, LocalTime = "05:00", Volume = 150 },
                new PowerPosition { Position = 8, LocalTime = "06:00", Volume = 150 },
                new PowerPosition { Position = 9, LocalTime = "07:00", Volume = 150 },
                new PowerPosition { Position = 10, LocalTime = "08:00", Volume = 150 },
                    new PowerPosition { Position = 11, LocalTime = "09:00", Volume = 150 },
                        new PowerPosition { Position = 12, LocalTime = "10:00", Volume = 80 },
                            new PowerPosition { Position = 13, LocalTime = "11:00", Volume = 80 },
                                new PowerPosition { Position = 14, LocalTime = "12:00", Volume = 80 },
                                    new PowerPosition { Position = 15, LocalTime = "13:00", Volume = 80 },
                                        new PowerPosition { Position = 16, LocalTime = "14:00", Volume = 80 },
                                            new PowerPosition { Position = 17, LocalTime = "15:00", Volume = 80 },
                                                new PowerPosition { Position = 18, LocalTime = "16:00", Volume = 80 },
                                                    new PowerPosition { Position = 19, LocalTime = "17:00", Volume = 80 },
                                                        new PowerPosition { Position = 20, LocalTime = "18:00", Volume = 80 },
                                                            new PowerPosition { Position = 21, LocalTime = "19:00", Volume = 80 },
                                                                new PowerPosition { Position = 22, LocalTime = "20:00", Volume = 80 },
                                                                    new PowerPosition { Position = 23, LocalTime = "21:00", Volume = 80 },
                                                                        new PowerPosition { Position = 24, LocalTime = "22:00", Volume = 80 }
            };
        }
    }
}




