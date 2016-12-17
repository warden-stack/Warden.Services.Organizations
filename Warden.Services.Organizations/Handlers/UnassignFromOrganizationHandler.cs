using System.Threading.Tasks;
using Warden.Common.Commands;
using Warden.Services.Organizations.Services;
using Warden.Services.Organizations.Shared.Commands;

namespace Warden.Services.Organizations.Handlers
{
    public class UnassignFromOrganizationHandler : ICommandHandler<UnassignUserFromOrganization>
    {
        private readonly IOrganizationService _organizationService;

        public UnassignFromOrganizationHandler(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        public async Task HandleAsync(UnassignUserFromOrganization command)
        {
            await _organizationService.UnassignUserAsync(command.OrganizationId, command.UserId);
        }
    }
}