using AutoMapper;
using Nancy;
using Warden.Services.Organizations.Domain;
using Warden.Services.Organizations.Queries;
using Warden.Services.Organizations.Services;
using Warden.Services.Organizations.Dto;

namespace Warden.Services.Organizations.Modules
{
    public class OrganizationsModule : ModuleBase
    {
        public OrganizationsModule(IOrganizationService organizationService, IMapper mapper) : base(mapper, "organizations")
        {
            Get("{id}", async args => await Fetch<GetOrganization, Organization>
                (async x => await organizationService.GetAsync(x.UserId, x.Id))
                .MapTo<OrganizationDto>()
                .HandleAsync());
        }
    }
}