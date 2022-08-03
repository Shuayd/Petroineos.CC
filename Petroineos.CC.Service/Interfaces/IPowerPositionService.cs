using Petroineos.CC.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petroineos.CC.Service.Interfaces
{
    public interface IPowerPositionService
    {
        IEnumerable<PowerPosition> GetPowerPosition(DateTime date);
    }
}
