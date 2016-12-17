using System.Threading.Tasks;
using Warden.Common.Commands;
using Warden.Services.Organizations.Services;
using Warden.Services.Organizations.Shared.Commands;

namespace Warden.Services.Organizations.Handlers
{
    public class AssignUserToOrganizationHandler : ICommandHandler<AssignUserToOrganization>
    {
        private readonly IOrganizationService _organizationServixce;

        public AssignUserToOrganizationHandler(IOrganizationService organizationServixce)
        {
            _organizationServixce = organizationServixce;
        }

        public async Task HandleAsync(AssignUserToOrganization command)
        {
            await _organizationServixce.AssignUserAsync(command.OrganizationId,
                command.UserId, command.Email, command.Role);
        }
    }
}