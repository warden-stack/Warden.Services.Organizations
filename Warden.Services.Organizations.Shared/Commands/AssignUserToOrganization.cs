﻿using System;
using Warden.Common.Commands;

namespace Warden.Services.Organizations.Shared.Commands
{
    public class AssignUserToOrganization : IAuthenticatedCommand
    {
        public Request Request { get; set; }
        public string UserId { get; set; }
        public Guid OrganizationId { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}