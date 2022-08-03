using Petroineos.CC.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petroineos.CC.Service.Interfaces
{
    public interface IReportService
    {
        void ExportToCSV(List<PowerPosition> powerPositions, DateTime date);
    }
}
