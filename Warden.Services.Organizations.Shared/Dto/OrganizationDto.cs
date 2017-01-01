using System;
using System.Collections.Generic;

namespace Warden.Services.Organizations.Shared.Dto
{
    public class OrganizationDto
    {
        public Guid Id { get; set; }
        public UserInOrganizationDto Owner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<UserInOrganizationDto> Users { get; set; }
        public IList<WardenDto> Wardens { get; set; }
    }
}