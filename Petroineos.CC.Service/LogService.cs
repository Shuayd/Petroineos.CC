using Microsoft.Extensions.Logging;
using Petroineos.CC.Service.Interfaces;
using System;

namespace Petroineos.CC.Service
{
    public class LogService : ILogService
    {
        //For logging capability use azure app insights to log errors in application
        private readonly ILogger<LogService> _logService;
        public void Log(Exception ex)
        {
            _logService.LogError(ex.Message);
        }
    }
}
