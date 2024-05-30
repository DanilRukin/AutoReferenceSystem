using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Domain.Dtos
{
    public class AbstractOptionsDto
    {
        public int ModelId { get; set; }

        public AbstractionMethod AbstractionMethod { get; set; } = AbstractionMethod.Extraction;

        public AbstractVolume AbstractVolume { get; set; } = AbstractVolume.Absolute;

        public ExpectedResult ExpectedResult { get; set; } = ExpectedResult.Text;

        public ProblemType ProblemType { get; set; } = ProblemType.HighlightTheMainTheses;
    }
}
