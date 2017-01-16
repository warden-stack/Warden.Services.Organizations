using System;
using Warden.Common.Events;

namespace Warden.Services.Organizations.Shared.Events
{
    public class CreateWardenRejected : IRejectedEvent
    {
        public Guid RequestId { get; }
        public string UserId { get; }
        public string Code { get; }
        public string Reason { get; }
        public string Name { get; }
        public Guid OrganizationId { get; }

        public CreateWardenRejected(Guid requestId,
            string userId, string code,
            string reason, string name,
            Guid organizationId)
        {
            RequestId = requestId;
            UserId = userId;
            Code = code;
            Reason = reason;
            Name = name;
            OrganizationId = organizationId;
        }
    }
}