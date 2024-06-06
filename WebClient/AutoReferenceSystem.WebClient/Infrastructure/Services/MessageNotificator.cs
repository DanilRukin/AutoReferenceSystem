using AntDesign;
using System;
using System.Threading.Tasks;

namespace AutoReferenceSystem.WebClient.Infrastructure.Services
{
    public class MessageNotificator : IMessageNotificator
    {
        private INotificationService _notificationService;

        public MessageNotificator(INotificationService notificationService)
        {
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
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
            await _notificationService.Open(config);
        }

        public async Task ShowError(string message) => await ShowNotification("Ошибка", message, NotificationType.Error);

        public async Task ShowSuccess(string message) => await ShowNotification("Успешно", message, NotificationType.Success);

        public async Task ShowWarning(string message) => await ShowNotification("Предупреждение", message, NotificationType.Warning);

        public async Task ShowInfo(string message) => await ShowNotification("Информация", message, NotificationType.Info);
    }
}
