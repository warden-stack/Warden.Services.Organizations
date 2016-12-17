using System;
using Warden.Common.Events;

namespace Warden.Services.Organizations.Shared.Events
{
    public class OrganizationDeleted : IAuthenticatedEvent
    {
        public Guid RequestId { get; }
        public Guid OrganizationId { get; }
        public string UserId { get; }

        protected OrganizationDeleted()
        {
        }

        public OrganizationDeleted(Guid requestId, Guid organizationId, string userId)
        {
            RequestId = requestId;
            OrganizationId = organizationId;
            UserId = userId;
        }
    }
}