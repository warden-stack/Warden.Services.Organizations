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
    public class AssignUserToOrganizationHandler : ICommandHandler<AssignUserToOrganization>
    {
        private readonly IHandler _handler;
        private readonly IBusClient _bus;
        private readonly IOrganizationService _organizationService;

        public AssignUserToOrganizationHandler(IHandler handler, IBusClient bus,
            IOrganizationService organizationService)
        {
            _handler = handler;
            _bus = bus;
            _organizationService = organizationService;
        }

        public async Task HandleAsync(AssignUserToOrganization command)
        {
            await _handler
                .Run(async () => await _organizationService.AssignUserAsync(command.OrganizationId,
                    command.UserId, command.UserToAssignId, command.Role))
                .OnSuccess(async () => await _bus.PublishAsync(new UserAssignedToOrganization(command.Request.Id, command.UserId,
                    command.OrganizationId, command.UserToAssignId)))
                .OnCustomError(async ex => await _bus.PublishAsync(new AssignUserToOrganizationRejected(command.Request.Id,
                    command.UserId, ex.Code, ex.Message, command.OrganizationId,command.UserToAssignId)))
                .OnError(async (ex, logger) =>
                {
                    logger.Error(ex, "Error occured while assigning a user to organization.");
                    await _bus.PublishAsync(new AssignUserToOrganizationRejected(command.Request.Id,
                        command.UserId, OperationCodes.Error, ex.Message, command.OrganizationId,command.UserToAssignId));
                })
                .ExecuteAsync();
        }
    }
}