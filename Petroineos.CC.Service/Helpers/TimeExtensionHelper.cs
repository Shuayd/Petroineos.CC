using System;
using System.Collections.Generic;

namespace Petroineos.CC.Service.Helpers
{
    public static class TimeExtensionHelper
    {
        public static string ToLocalTime(this int val)
        {
            int period = 1;
            Dictionary<int, string> time = new Dictionary<int, string>();
            var startTime = DateTime.Parse("2022-08-02 23:00:00");
            var endTime = startTime.AddHours(23);
            while (startTime <= endTime)
            {
                time.Add(period++, startTime.ToShortTimeString());
                startTime = startTime.AddHours(1);
            }
            return time[val];
        }
    }
}
