using AutoReferenceSystem.WebClient.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using System.Text.Json;
using System;

namespace AutoReferenceSystem.WebClient.Pages
{
    public partial class LoginPage
    {
        public LoginViewModel Model { get; set; } = new LoginViewModel();

        private void OnFinish(EditContext editContext)
        {
            Console.WriteLine($"Success:{JsonSerializer.Serialize(Model)}");
        }

        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed:{JsonSerializer.Serialize(Model)}");
        }
    }
}
