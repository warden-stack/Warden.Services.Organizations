using System;
using Warden.Common.Events;

namespace Warden.Services.Organizations.Shared.Events
{
    public class UpdateOrganizationRejected : IRejectedEvent
    {
        public Guid RequestId { get; }
        public string UserId { get; }
        public string Code { get; }
        public string Reason { get; }
        public Guid OrganizationId { get; }

        protected UpdateOrganizationRejected()
        {
        }

        public UpdateOrganizationRejected(Guid requestId,
            string userId, string code,
            string reason, Guid organizationId)
        {
            RequestId = requestId;
            UserId = userId;
            Code = code;
            Reason = reason;
            OrganizationId = organizationId;
        }
    }
}