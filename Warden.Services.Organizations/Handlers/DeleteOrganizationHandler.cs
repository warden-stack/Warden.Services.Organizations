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
    public class DeleteOrganizationHandler : ICommandHandler<DeleteOrganization>
    {
        private readonly IHandler _handler;
        private readonly IBusClient _bus;
        private readonly IOrganizationService _organizationService;

        public DeleteOrganizationHandler(IHandler handler, IBusClient bus,
            IOrganizationService organizationService)
        {
            _handler = handler;
            _bus = bus;
            _organizationService = organizationService;
        }

        public async Task HandleAsync(DeleteOrganization command)
        {
            await _handler
                .Run(async () => await _organizationService.DeleteAsync(command.Id, command.UserId))
                .OnSuccess(async () => await _bus.PublishAsync(new OrganizationDeleted(command.Request.Id, 
                    command.Id, command.UserId))
                )
                .OnCustomError(async ex => await _bus.PublishAsync(new DeleteOrganizationRejected(command.Request.Id,
                    command.UserId, ex.Code, ex.Message,command.Id)))
                .OnError(async (ex, logger) =>
                {
                    logger.Error(ex, "Error occured while deleting an organization.");
                    await _bus.PublishAsync(new DeleteOrganizationRejected(command.Request.Id,
                        command.UserId, OperationCodes.Error, ex.Message, command.Id));
                })
                .ExecuteAsync();
        }
    }
}