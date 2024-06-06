using AutoReferenceSystem.ApplicationServer.Domain.Dtos;
using System.Collections.Generic;

namespace AutoReferenceSystem.WebClient.Models
{
    public class ReferencingModel
    {
        public ProblemType ProblemType { get; set; } = ProblemType.HighlightTheMainTheses;

        public AbsoluteAbstractVolumeMeasure Measure { get; set; } = AbsoluteAbstractVolumeMeasure.WordsCount;

        public AbstractVolume AbstractVolume { get; set; } = AbstractVolume.Relative;

        public AbstractionMethod AbstractionMethod { get; set; } = AbstractionMethod.Extraction;

        public ExpectedResult ExpectedResult { get; set; } = ExpectedResult.ListOfAbstracts;

        public int? AbstractsCount { get; set; }
        public int? WordsCount { get; set; }
        public int? SentenciesCount { get; set; }
        public double AbstractRelativeVolume { get; set; }

        public string SourceText { get; set; } = string.Empty;
        public string ResultText { get; set; } = string.Empty;

        public int? SelectedFileFormatId { get; set; }


        public List<FileFormat> FileSaveFormats { get; set; } = new List<FileFormat>
        {
            new() { Id = 1, Name = "pdf" },
            new() { Id = 2, Name = "docx" }
        };

        public List<LanguageModel> Models { get; set; } = new List<LanguageModel>()
        {
            new() { Id = 1, Name = "BERT" },
            new() { Id = 2, Name = "BART" },
            new() { Id = 3, Name = "Llama" }
        };

        public int? SelectedModelId { get; set; }

    }
}
