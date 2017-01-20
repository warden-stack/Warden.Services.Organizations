using System;
using Warden.Common.Events;

namespace Warden.Services.Organizations.Shared.Events
{
    public class DeleteWardenRejected : IRejectedEvent
    {
        public Guid RequestId { get; }
        public string UserId { get; }
        public string Code { get; }
        public string Reason { get; }
        public Guid OrganizationId { get; }
        public Guid WardenId { get; }

        protected DeleteWardenRejected()
        {
        }

        public DeleteWardenRejected(Guid requestId,
            string userId, string code,
            string reason, Guid organizationId,
            Guid wardenId)
        {
            RequestId = requestId;
            UserId = userId;
            Code = code;
            Reason = reason;
            OrganizationId = organizationId;
            WardenId = wardenId;
        }
    }
}