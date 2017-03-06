using System.Threading.Tasks;
using Warden.Messages.Commands;
using Warden.Services.Organizations.Services;
using Warden.Messages.Commands.Organizations;

namespace Warden.Services.Organizations.Handlers
{
    public class UpdateOrganizationHandler : ICommandHandler<UpdateOrganization>
    {
        private readonly IOrganizationService _organizationService;

        public UpdateOrganizationHandler(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        public async Task HandleAsync(UpdateOrganization command)
        {
            await _organizationService.UpdateAsync(command.Id, command.Name, command.UserId);
        }
    }
}