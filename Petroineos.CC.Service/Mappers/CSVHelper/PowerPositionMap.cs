using CsvHelper.Configuration;
using Petroineos.CC.Service.Models;

namespace Petroineos.CC.Service.Mappers.CSVHelper
{
    public class PowerPositionMap : ClassMap<PowerPosition>
    {
        public PowerPositionMap()
        {
            Map(m => m.LocalTime).Index(0).Name("Local Time");
            Map(m => m.Volume).Index(1).Name("Volume");
            Map(m => m.Position).Ignore();
        }
    }
}
