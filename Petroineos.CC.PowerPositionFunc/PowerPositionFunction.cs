using System;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Petroineos.CC.Service.Interfaces;

namespace Petroineos.CC.PowerPositionFunc
{
    public class PowerPositionFunction
    {
        private readonly IPowerPositionService _powerPositionService;
        private readonly IReportService _reportService;
        private readonly ILogService _logService;

        public PowerPositionFunction(IPowerPositionService powerPositionService, IReportService reportService, ILogService logService)
        {
            _powerPositionService = powerPositionService;
            _logService = logService;
            _reportService = reportService;
        }

        [FunctionName("PowerPositionFunction")]
        public void Run([TimerTrigger("%TimerInterval%")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"PowerPositionFunction Timer  trigger function executed at: {DateTime.Now}");
            try
            {
                var date = DateTime.Now;
                var powerPositions = _powerPositionService.GetPowerPosition(date).ToList();
                if (powerPositions != null)
                {
                    _reportService.ExportToCSV(powerPositions, date);
                }
            }
            catch (Exception ex)
            {
                _logService.Log(ex);
            }
            log.LogInformation($"PowerPositionFunction Timer trigger function executed at: {DateTime.Now}");

        }
    }
}
