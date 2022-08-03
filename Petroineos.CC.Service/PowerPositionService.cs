using Petroineos.CC.Service.Helpers;
using Petroineos.CC.Service.Interfaces;
using Petroineos.CC.Service.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petroineos.CC.Service
{
    public class PowerPositionService : IPowerPositionService
    {
        private readonly IPowerService _powerService;

        public PowerPositionService(IPowerService powerService)
        {
            _powerService = powerService;
        }

        public IEnumerable<PowerPosition> GetPowerPosition(DateTime date)
        {
            var periods = new List<PowerPeriod>();
            var trades = _powerService.GetTrades(date);
            var tradePeriods = trades.Select(x => x.Periods).ToList();

            tradePeriods.ForEach(d =>
            {
                periods.AddRange(d);
            });

            var powerPositions = periods.GroupBy(x => x.Period).Select(
                            p => new PowerPosition
                            {
                                LocalTime = p.Key.ToLocalTime(),
                                Volume = p.Sum(s => s.Volume),
                                Position = p.Key
                            }).OrderBy(x => x.Position).ToList();

            return powerPositions;
        }
    }
}
