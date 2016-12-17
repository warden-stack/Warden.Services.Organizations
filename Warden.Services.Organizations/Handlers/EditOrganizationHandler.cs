using System.Threading.Tasks;
using Warden.Common.Commands;
using Warden.Services.Organizations.Services;
using Warden.Services.Organizations.Shared.Commands;

namespace Warden.Services.Organizations.Handlers
{
    public class EditOrganizationHandler : ICommandHandler<EditOrganization>
    {
        private readonly IOrganizationService _organizationService;

        public EditOrganizationHandler(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        public async Task HandleAsync(EditOrganization command)
        {
            await _organizationService.UpdateAsync(command.Id, command.Name, command.UserId);
        }
    }
}