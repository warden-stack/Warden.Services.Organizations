using System.Threading.Tasks;
using Warden.Common.Events;
using Warden.Services.Organizations.Domain;
using Warden.Services.Organizations.Repositories;
using Warden.Services.Users.Shared.Events;

namespace Warden.Services.Organizations.Handlers
{
    public class SignedUpHandler : IEventHandler<SignedUp>
    {
        private readonly IUserRepository _userRepository;

        public SignedUpHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task HandleAsync(SignedUp @event)
        {
            await _userRepository.AddAsync(new User(@event.UserId, @event.Email, @event.Role, @event.State));
        }
    }
}