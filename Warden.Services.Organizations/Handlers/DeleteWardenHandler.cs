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
    public class DeleteWardenHandler : ICommandHandler<DeleteWarden>
    {
        private readonly IHandler _handler;
        private readonly IBusClient _bus;
        private readonly IWardenService _wardenService;

        public DeleteWardenHandler(IHandler handler, IBusClient bus,
            IWardenService wardenService)
        {
            _handler = handler;
            _bus = bus;
            _wardenService = wardenService;
        }

        public async Task HandleAsync(DeleteWarden command)
        {
            await _handler
                .Run(async () => await _wardenService.DeleteWardenAsync(command.WardenId, command.OrganizationId, command.UserId))
                .OnSuccess(async () => await _bus.PublishAsync(new WardenDeleted(command.Request.Id, command.UserId,
                    command.WardenId, command.OrganizationId)))
                .OnCustomError(async ex => await _bus.PublishAsync(new DeleteWardenRejected(command.Request.Id,
                    command.UserId, ex.Code, ex.Message,command.OrganizationId, command.WardenId)))
                .OnError(async (ex, logger) =>
                {
                    logger.Error(ex, "Error occured while deleting a warden.");
                    await _bus.PublishAsync(new DeleteWardenRejected(command.Request.Id,
                    command.UserId, OperationCodes.Error, ex.Message,command.OrganizationId, 
                        command.WardenId));
                })
                .ExecuteAsync();
        }        
    }
}