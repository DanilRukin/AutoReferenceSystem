using AntDesign;
using AutoReferenceSystem.ApplicationServer.Domain.Dtos;
using AutoReferenceSystem.WebClient.Logic.Extensions;
using AutoReferenceSystem.WebClient.Logic.Referencing.Queries;
using AutoReferenceSystem.WebClient.Models;
using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoReferenceSystem.WebClient.Pages
{
    public partial class Referencing
    {
        private string _style = "line-height:50px";

        [Inject]
        protected INotificationService NotificationService { get; set; }

        [Inject]
        protected IMediator Mediator { get; set; }

        public ReferencingModel Model { get; set; }

        public string ActiveTabKey { get; set; } = "1";

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

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Model = new ReferencingModel();
        }


        private async Task OnReferencingButtonClick()
        {          
            if (ActiveTabKey == "1") // По типу решаемой задачи
            {
                // Установим значения настроек по-умолчанию
                Model.SelectedModelId = 1;
                Model.AbstractionMethod = AbstractionMethod.Abstraction;
                Model.AbstractVolume = AbstractVolume.Absolute;
                Model.Measure = AbsoluteAbstractVolumeMeasure.WordsCount;
            }
            GetAnAbstractQuery query = new(
                Model.SourceText,
                Model.SelectedModelId == null ? 0 : (int)Model.SelectedModelId,
                Model.AbstractionMethod,
                Model.AbstractVolume,
                Model.Measure,
                Model.WordsCount == null ? 0 : (int)Model.WordsCount,
                Model.SentenciesCount == null ? 0 : (int)Model.SentenciesCount,
                Model.AbstractRelativeVolume,
                Guid.Parse("ecfe7fc8-9c0a-4ac3-a970-e964be2afac1") // TODO: user!!!!
                );
            var result = await Mediator.Send(query);
            if (!result.IsSuccess)
            {
                ShowWarning(result.Errors.AsOneString());
            }
            else
            {
                ShowSuccess("Реферат успешно сформирован");
                Model.ResultText = result.Value.Abstract;
            }               
        }

        private async Task OnSaveButtonClick()
        {
            if (string.IsNullOrWhiteSpace(Model.ResultText))
            {
                await ShowWarning("Для сохранения файла необходимо, чтобы был получен пересказ");
                return;
            }
            if (Model.SelectedFileFormatId == null)
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
