using System.Threading.Tasks;
using RawRabbit;
using Warden.Messages.Events;
using Warden.Services.Organizations.Repositories;
using Warden.Services.Organizations.Services;
using Warden.Messages.Events.Users;

namespace Warden.Services.Organizations.Handlers
{
    public class SignedInHandler : IEventHandler<SignedIn>
    {
        private readonly IBusClient _bus;
        private readonly IUserRepository _userRepository;
        private readonly IOrganizationService _organizationService;

        public SignedInHandler(IBusClient bus,
            IUserRepository userRepository,
            IOrganizationService organizationService)
        {
            _bus = bus;
            _userRepository = userRepository;
            _organizationService = organizationService;
        }

        public async Task HandleAsync(SignedIn @event)
        {
            var user = await _userRepository.GetAsync(@event.UserId);
            if (user.HasValue)
                return;
        }
    }
}