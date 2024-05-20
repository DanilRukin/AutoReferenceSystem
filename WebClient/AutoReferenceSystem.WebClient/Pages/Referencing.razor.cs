using AntDesign;
using AutoReferenceSystem.WebClient.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoReferenceSystem.WebClient.Pages
{
    public partial class Referencing
    {
        [Inject]
        protected INotificationService NotificationService { get; set; }

        public ProblemType ProblemType { get; set; } = ProblemType.HighlightTheMainTheses;

        public RelativeAbstractVolumeMeasure Measure { get; set; } = RelativeAbstractVolumeMeasure.WordsCount;

        public AbstractVolume AbstractVolume { get; set; } = AbstractVolume.Relative;

        public AbstractionMethod AbstractionMethod { get; set; } = AbstractionMethod.Extraction;

        public ExpectedResult ExpectedResult { get; set; } = ExpectedResult.ListOfAbstracts;

        public int? AbstractsCount { get; set; }
        public int? WordsCount { get; set; }
        public int? SentenciesCount { get; set; }
        public double AbstractRelativeVolume { get; set; }

        public string SourceText { get; set; } = string.Empty;
        public string ResultText { get; set; } = string.Empty;

        public string ActiveTabKey { get; set; } = "1";

        private List<FileFormat> FileSaveFormats { get; set; } = new List<FileFormat>
        { 
            new() { Id = 1, Name = "pdf" },
            new() { Id = 2, Name = "docx" }
        };

        private int? SelectedFileFormatId { get; set; }

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

        private int? SelectedModelId { get; set; }

        private string _style = "line-height:50px";

        private async Task OnReferencingButtonClick()
        {
            if (string.IsNullOrWhiteSpace(SourceText))
            {
                await ShowWarning("Введите хоть какой-нибудь текст или прикрепите файл!");
                return;
            }
            if (SelectedModelId is null)
            {
                await ShowWarning("Выберите модель");
                return;
            }
            if (ActiveTabKey == "1") // По типу решаемой задачи
            {
                if (ProblemType == ProblemType.HighlightTheMainTheses) // выделить основные тезисы
                {
                    if (AbstractsCount == null || AbstractsCount < 1)
                    {
                        await ShowWarning("Должно быть задано количество тезисов");
                        return;
                    }
                    // TODO: Выделяем основные тезисы
                    AbstractionMethod = AbstractionMethod.Extraction;
                }
                else if (ProblemType == ProblemType.BuildReferencing) // Построить полносвязный пересказ
                {
                    // Установить по-дефолту метод реферирования
                    AbstractionMethod = AbstractionMethod.Abstraction;
                    await GetAnAbstractWithCurrentUserReferencingSettings();
                }
                else
                {
                    await ShowError("Не выбрана решаемая проблема");
                    return;
                }
            }
            else if (ActiveTabKey == "2") // Пользовательские
            {
                if (AbstractionMethod == AbstractionMethod.Extraction) // экстракция
                {
                    // TODO: отфильтровать модели, которые можно использовать. Использовать установленный пользователем метод реферирования
                    await GetAnAbstractWithCurrentUserReferencingSettings();
                }
                else if (AbstractionMethod == AbstractionMethod.Abstraction) // Абстракция
                {
                    // TODO: отфильтровать модели, которые можно использовать. Использовать установленный пользователем метод реферирования
                    await GetAnAbstractWithCurrentUserReferencingSettings();
                }
                else
                {
                    await ShowError("Не выбран метод реферирования");
                    return;
                }
            }
            else
            {
                await ShowError("Не заданы настройки реферирования");
            }
        }

        private async Task GetAnAbstractWithCurrentUserReferencingSettings()
        {
            if (AbstractVolume == AbstractVolume.Relative)
            {
                if (AbstractRelativeVolume < 1)
                {
                    await ShowWarning("Должно быть задано процентное соотношение объема получаемого текста к объему исходного");
                    return;
                }
                // TODO: Строим полносвязный реферат (относительный объем)
            }
            else if (AbstractVolume == AbstractVolume.Absolute)
            {
                if (Measure == RelativeAbstractVolumeMeasure.WordsCount)
                {
                    if (WordsCount == null || WordsCount < 1)
                    {
                        await ShowWarning("Должно быть задано количество слов");
                        return;
                    }
                    // TODO: Строим полносвязный реферат (абсолютный объем в словах)
                }
                else if (Measure == RelativeAbstractVolumeMeasure.SentenciesCount)
                {
                    if (SentenciesCount == null || SentenciesCount < 1)
                    {
                        await ShowWarning("Должно быть задано количество предложений");
                        return;
                    }
                    // TODO: Строим полносвязный реферат (абсолютный объем в предложениях)
                }
                else
                {
                    await ShowError("Не выбрана мера абсолютного объема реферата");
                    return;
                }
            }
            else
            {
                await ShowError("Не выбрана мера реферата");
                return;
            }
        }

        private async Task OnSaveButtonClick()
        {
            if (string.IsNullOrWhiteSpace(ResultText))
            {
                await ShowWarning("Для сохранения файла необходимо, чтобы был получен пересказ");
                return;
            }
            if (SelectedFileFormatId == null)
            {
                await ShowWarning("Не выбран формат сохранения файла");
                return;
            }
            // TODO: Save file
        }

        private async Task ShowNotification(string title, string description, NotificationType notificationType)
        {
            var config = new NotificationConfig()
            {
                Message = title,
                Description = description,
                Placement = NotificationPlacement.BottomLeft,
                NotificationType = notificationType
            };
            await NotificationService.Open(config);
        }

        private async Task ShowError(string message) => await ShowNotification("Ошибка", message, NotificationType.Error);

        private async Task ShowSuccess(string message) => await ShowNotification("Успешно", message, NotificationType.Success);

        private async Task ShowWarning(string message) => await ShowNotification("Предупреждение", message, NotificationType.Warning);

        private async Task ShowInfo(string message) => await ShowNotification("Информация", message, NotificationType.Info);
    }
}
