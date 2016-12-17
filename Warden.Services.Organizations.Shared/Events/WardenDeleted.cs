using System;
using Warden.Common.Events;

namespace Warden.Services.Organizations.Shared.Events
{
    public class WardenDeleted : IAuthenticatedEvent
    {
        public Guid RequestId { get; }
        public string UserId { get; }
        public Guid WardenId { get; }
        public Guid OrganizationId { get; }

        protected WardenDeleted()
        {
        }

        public WardenDeleted(Guid requestId, string userId,
            Guid wardenId, Guid organizationId)
        {
            RequestId = requestId;
            UserId = userId;
            WardenId = wardenId;
            OrganizationId = organizationId;
        }
    }
}