using System;
using Warden.Common.Events;

namespace Warden.Services.Organizations.Shared.Events
{
    public class AssignUserToOrganizationRejected : IRejectedEvent
    {
        public Guid RequestId { get; }
        public string UserId { get; }
        public string Code { get; }
        public string Reason { get; }
        public Guid OrganizationId { get; }
        public string UserToAssignId { get; }

        protected AssignUserToOrganizationRejected()
        {
        }

        public AssignUserToOrganizationRejected(Guid requestId,
            string userId, string code,
            string reason, Guid organizationId,
            string userToAssignId)
        {
            RequestId = requestId;
            UserId = userId;
            Code = code;
            Reason = reason;
            OrganizationId = organizationId;
            UserToAssignId = userToAssignId;
        }
    }
}