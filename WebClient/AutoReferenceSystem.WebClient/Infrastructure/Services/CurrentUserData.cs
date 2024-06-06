using System;

namespace AutoReferenceSystem.WebClient.Infrastructure.Services
{
    public class CurrentUserData
    {
        public Guid UserId { get; set; } = Guid.Empty;

        public Guid CurrentSessionId { get; set; } = Guid.Empty;
    }
}
