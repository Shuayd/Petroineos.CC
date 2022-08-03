using CsvHelper;
using Microsoft.Extensions.Options;
using Petroineos.CC.Service.Configuration;
using Petroineos.CC.Service.Helpers;
using Petroineos.CC.Service.Interfaces;
using Petroineos.CC.Service.Mappers.CSVHelper;
using Petroineos.CC.Service.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Petroineos.CC.Service
{
    public class ReportService : IReportService
    {
        private readonly AppSettings _settings;

        public ReportService(IOptions<AppSettings> options)
        {
            _settings = options.Value;
        }

        public void ExportToCSV(List<PowerPosition> powerPositions, DateTime date)
        {
            string path = $"{_settings.CSVFilePath}\\{FileExtensionHelper.GetFileName(Convert.ToInt32(powerPositions.Sum(p=>p.Volume)), date)}";

            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<PowerPositionMap>();
                csv.WriteHeader<PowerPosition>();
                csv.NextRecord();
                foreach (var powerPosition in powerPositions)
                {
                    csv.WriteRecord(powerPosition);
                    csv.NextRecord();
                }
            }
        }
    }
}
