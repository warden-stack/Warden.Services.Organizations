using System;
using Warden.Common.Commands;

namespace Warden.Services.Organizations.Shared.Commands
{
    public class CreateOrganization : IAuthenticatedCommand
    {
        public Request Request { get; set; }
        public string UserId { get; set; }
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}