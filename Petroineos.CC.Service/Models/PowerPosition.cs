using CsvHelper.Configuration.Attributes;
using System;

namespace Petroineos.CC.Service.Models
{
    public class PowerPosition
    {
        public string LocalTime { get; set; }
        public double Volume { get; set; }
        [Ignore]
        public int Position { get; set; }

    }
}
