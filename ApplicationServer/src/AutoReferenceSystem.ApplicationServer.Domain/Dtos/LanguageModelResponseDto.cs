using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Domain.Dtos
{
    public class LanguageModelResponseDto
    {
        public string Abstract { get; set; } = string.Empty;
        public TimeSpan WorkingTime { get; set; }
    }
}
