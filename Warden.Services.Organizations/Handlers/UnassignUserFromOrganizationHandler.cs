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
    public class UnassignUserFromOrganizationHandler : ICommandHandler<UnassignUserFromOrganization>
    {
        private readonly IHandler _handler;
        private readonly IBusClient _bus;
        private readonly IOrganizationService _organizationService;

        public UnassignUserFromOrganizationHandler(IHandler handler, IBusClient bus,
            IOrganizationService organizationService)
        {
            _handler = handler;
            _bus = bus;
            _organizationService = organizationService;
        }

        public async Task HandleAsync(UnassignUserFromOrganization command)
        {
            await _handler
                .Run(async () => await _organizationService.UnassignUserAsync(command.OrganizationId,
                    command.UserToUnassignId))
                .OnSuccess(async () => await _bus.PublishAsync(new UserUnassignedFromOrganization(command.Request.Id, 
                    command.UserId, command.OrganizationId, command.UserToUnassignId)))
                .OnCustomError(async ex => await _bus.PublishAsync(new UnassignUserFromOrganizationRejected(command.Request.Id,
                    command.UserId, ex.Code, ex.Message, command.OrganizationId, command.UserToUnassignId)))
                .OnError(async (ex, logger) =>
                {
                    logger.Error(ex, "Error occured while unassigned a user from organization.");
                    await _bus.PublishAsync(new UnassignUserFromOrganizationRejected(command.Request.Id,
                    command.UserId, OperationCodes.Error, ex.Message, command.OrganizationId, command.UserToUnassignId));
                })
                .ExecuteAsync();
        }
    }
}