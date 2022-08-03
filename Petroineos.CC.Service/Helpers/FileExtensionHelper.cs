using System;

namespace Petroineos.CC.Service.Helpers
{
    public static class FileExtensionHelper
    {

        public static string GetFileName(int powerPosition, DateTime date)
        {
            return $"{powerPosition}_{date.ToString("yyyyMMdd_HHmm")}.csv";
        }
    }
}
