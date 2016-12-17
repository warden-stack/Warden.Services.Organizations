using System.Linq;
using System.Threading.Tasks;
using RawRabbit;
using Warden.Common.Commands;
using Warden.Services.Organizations.Services;
using Warden.Services.Organizations.Shared.Commands;
using Warden.Services.Organizations.Shared.Events;

namespace Warden.Services.Organizations.Handlers
{
    public class CreateOrganizationHandler : ICommandHandler<CreateOrganization>
    {
        private readonly IBusClient _bus;
        private readonly IOrganizationService _organizationService;

        public CreateOrganizationHandler(IBusClient bus, 
            IOrganizationService organizationService)
        {
            _bus = bus;
            _organizationService = organizationService;
        }

        public async Task HandleAsync(CreateOrganization command)
        {
            await _organizationService.CreateAsync(command.OrganizationId, command.UserId,
                command.Name, command.Description);
            var organization = await _organizationService.GetAsync(command.OrganizationId);
            var owner = organization.Value.Users.First(x => x.UserId == command.UserId);
            await _bus.PublishAsync(new OrganizationCreated(command.Request.Id, command.OrganizationId, command.Name,
                command.Description, command.UserId, owner.Email, owner.Role, owner.CreatedAt));
        }
    }
}