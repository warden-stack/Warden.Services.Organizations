using System;
using System.Threading.Tasks;
using RawRabbit;
using Warden.Common.Commands;
using Warden.Common.Handlers;
using Warden.Services.Organizations.Services;
using Warden.Services.Organizations.Shared;
using Warden.Services.Organizations.Shared.Commands;
using Warden.Services.Organizations.Shared.Events;

namespace Warden.Services.Organizations.Handlers
{
    public class CreateWardenHandler : ICommandHandler<CreateWarden>
    {
        private readonly IHandler _handler;
        private readonly IBusClient _bus;
        private readonly IWardenService _wardenService;


        public CreateWardenHandler(IHandler handler, IBusClient bus,
            IWardenService wardenService)
        {
            _handler = handler;
            _bus = bus;
            _wardenService = wardenService;
        }

        public async Task HandleAsync(CreateWarden command)
        {
            await _handler
                .Run(async () => await _wardenService.CreateWardenAsync(command.WardenId,
                    command.Name, command.OrganizationId, command.UserId, command.Enabled))
                .OnSuccess(async () => await _bus.PublishAsync(new WardenCreated(command.Request.Id, command.UserId,
                            command.WardenId, command.Name, command.OrganizationId,
                            DateTime.UtcNow, command.Enabled)))
                .OnCustomError(async ex => await _bus.PublishAsync(new CreateWardenRejected(command.Request.Id,
                    command.UserId, ex.Code, ex.Message, command.Name, command.OrganizationId)))
                .OnError(async (ex, logger) =>
                {
                    logger.Error(ex, "Error occured while creating a warden.");
                    await _bus.PublishAsync(new CreateWardenRejected(command.Request.Id,
                        command.UserId, OperationCodes.Error, ex.Message, command.Name, command.OrganizationId));
                })
                .ExecuteAsync();
        }
    }
}