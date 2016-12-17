using System;
using Warden.Common.Events;

namespace Warden.Services.Organizations.Shared.Events
{
    public class OrganizationUpdated : IAuthenticatedEvent
    {
        public Guid RequestId { get; }
        public Guid OrganizationId { get; }
        public string UserId { get; }

        protected OrganizationUpdated()
        {
        }

        public OrganizationUpdated(Guid requestId, Guid organizationId, string userId)
        {
            RequestId = requestId;
            OrganizationId = organizationId;
            UserId = userId;
        }
    }
}