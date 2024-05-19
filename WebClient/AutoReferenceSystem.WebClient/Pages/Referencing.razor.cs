using AntDesign;
using AutoReferenceSystem.WebClient.Models;
using System.Collections.Generic;

namespace AutoReferenceSystem.WebClient.Pages
{
    public partial class Referencing
    {
        public ProblemType ProblemType { get; set; } = ProblemType.HighlightTheMainTheses;

        public RelativeAbstractVolumeMeasure Measure { get; set; } = RelativeAbstractVolumeMeasure.WordsCount;

        public AbstractVolume AbstractVolume { get; set; } = AbstractVolume.Relative;

        private void OnSingleCompleted(UploadInfo fileinfo)
        {
            //if (fileinfo.File.State == UploadState.Success)
            //{
            //    var result = fileinfo.File.GetResponse<ResponseModel>();
            //    fileinfo.File.Url = result.url;
            //}
        }

        private string Format(double value)
        {
            return value.ToString() + "%";
        }

        private string Parse(string value)
        {
            return value.Replace("%", "");
        }


        private List<LanguageModel> Models { get; set; } = new List<LanguageModel>() 
        { 
            new() { Id = 1, Name = "BERT" },
            new() { Id = 2, Name = "BART" },
            new() { Id = 3, Name = "Llama" }
        };

        private int SelectedModelId { get; set; }

        private string _style = "line-height:50px";
    }
}
