using System;
using Warden.Common.Events;

namespace Warden.Services.Organizations.Shared.Events
{
    public class CreateOrganizationRejected : IRejectedEvent
    {
        public Guid RequestId { get; }
        public string UserId { get; }
        public string Code { get; }
        public string Reason { get; }
        public string Name { get; }

        protected CreateOrganizationRejected()
        {
        }

        public CreateOrganizationRejected(Guid requestId,
            string userId, string code,
            string reason, string name)
        {
            RequestId = requestId;
            UserId = userId;
            Code = code;
            Reason = reason;
            Name = name;
        }
    }
}