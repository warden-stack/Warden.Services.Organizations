using System;
using System.Threading.Tasks;
using RawRabbit;
using Warden.Common.Commands;
using Warden.Services.Organizations.Services;
using Warden.Services.Organizations.Shared.Commands;
using Warden.Services.Organizations.Shared.Events;

namespace Warden.Services.Organizations.Handlers
{
    public class CreateWardenHandler : ICommandHandler<CreateWarden>
    {
        private readonly IBusClient _bus;
        private readonly IWardenService _wardenService;

        public CreateWardenHandler(IBusClient bus, 
            IWardenService wardenService)
        {
            _bus = bus;
            _wardenService = wardenService;
        }

        public async Task HandleAsync(CreateWarden command)
        {
            await _wardenService.CreateWardenAsync(command.WardenId,
                command.Name, command.OrganizationId, command.UserId, command.Enabled);
            await _bus.PublishAsync(new WardenCreated(command.Request.Id, command.UserId,
                command.WardenId, command.Name, command.OrganizationId,
                DateTime.UtcNow, command.Enabled));
        }
    }
}