using AutoReferenceSystem.WebClient.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using System.Text.Json;
using System;
using Microsoft.AspNetCore.Components;
using AutoReferenceSystem.WebClient.Infrastructure.Services;
using System.Threading.Tasks;
using AutoReferenceSystem.WebClient.Infrastructure.Data;

namespace AutoReferenceSystem.WebClient.Pages
{
    public partial class LoginPage
    {
        public LoginViewModel Model { get; set; } = new LoginViewModel();

        [Inject]
        protected IMessageNotificator MessageNotificator { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected CurrentUserData CurrentUserData { get; set; }

        private void OnFinish(EditContext editContext)
        {
            Console.WriteLine($"Success:{JsonSerializer.Serialize(Model)}");
        }

        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed:{JsonSerializer.Serialize(Model)}");
        }

        private async Task LogIn()
        {
            // пока костылим без всяких сервайсов, так можно делать, потому что определение пользователя будет происходить только тут
            if (string.IsNullOrWhiteSpace(Model.UserName))
            {
                await MessageNotificator.ShowError("Не заполнено имя пользователя!");
                return;
            }
            if (string.IsNullOrWhiteSpace(Model.Password))
            {
                await MessageNotificator.ShowError("Не заполенен пароль!");
                return;
            }

            string tmpUserName = "guest";
            string tmpUserPassword = "123";

            if (Model.UserName != tmpUserName
                || Model.Password != tmpUserPassword)
            {
                await MessageNotificator.ShowError("Неверное имя пользователя или пароль!");
                return;
            }

            CurrentUserData.UserId = Guid.Parse("ecfe7fc8-9c0a-4ac3-a970-e964be2afac1");
            CurrentUserData.CurrentSessionId = Guid.Parse("32af054e-4c67-4d8c-846e-7baa76adfc22");

            NavigationManager.NavigateTo(PageAddresses.ReferencingPageAddress);
            return;
        }
    }
}
