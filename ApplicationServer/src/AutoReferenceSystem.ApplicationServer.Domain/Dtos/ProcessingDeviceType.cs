using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Domain.Dtos
{
    /// <summary>
    /// Тип устройства, на котором происходили расчеты
    /// </summary>
    public enum ProcessingDeviceType
    {
        Unknown, Cpu, Gpu
    }
}
