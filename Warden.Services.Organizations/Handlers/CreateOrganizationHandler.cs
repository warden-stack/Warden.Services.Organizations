using System.Linq;
using System.Threading.Tasks;
using RawRabbit;
using Warden.Messages.Commands;
using Warden.Common.Handlers;
using Warden.Services.Organizations.Services;
using Warden.Services.Organizations;
using Warden.Messages.Commands.Organizations;
using Warden.Messages.Events.Organizations;

namespace Warden.Services.Organizations.Handlers
{
    public class CreateOrganizationHandler : ICommandHandler<CreateOrganization>
    {
        private readonly IHandler _handler;
        private readonly IBusClient _bus;
        private readonly IOrganizationService _organizationService;

        public CreateOrganizationHandler(IHandler handler, IBusClient bus,
            IOrganizationService organizationService)
        {
            _handler = handler;
            _bus = bus;
            _organizationService = organizationService;
        }

        public async Task HandleAsync(CreateOrganization command)
        {
            await _handler
                .Run(async () => await _organizationService.CreateAsync(command.OrganizationId, 
                    command.UserId, command.Name, command.Description))
                .OnSuccess(async () =>
                {
                    var organization = await _organizationService.GetAsync(command.OrganizationId);
                    var owner = organization.Value.Users.First(x => x.UserId == command.UserId);
                    await _bus.PublishAsync(new OrganizationCreated(command.Request.Id, command.OrganizationId, 
                    command.Name, command.Description, command.UserId, owner.Email, owner.Role, owner.CreatedAt));
                })
                .OnCustomError(async ex => await _bus.PublishAsync(new CreateOrganizationRejected(command.Request.Id,
                    command.UserId, ex.Code, ex.Message, command.Name)))
                .OnError(async (ex, logger) =>
                {
                    logger.Error(ex, "Error occured while creating an organization.");
                    await _bus.PublishAsync(new CreateOrganizationRejected(command.Request.Id,
                        command.UserId, OperationCodes.Error, ex.Message, command.Name));
                })
                .ExecuteAsync();
        }
    }
}