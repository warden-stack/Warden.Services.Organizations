using System;
using Warden.Common.Commands;

namespace Warden.Services.Organizations.Shared.Commands
{
    public class UpdateOrganization : IAuthenticatedCommand
    {
        public Request Request { get; set; }
        public string UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}