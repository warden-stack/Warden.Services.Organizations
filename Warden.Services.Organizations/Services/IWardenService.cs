using System;
using System.Threading.Tasks;

namespace Warden.Services.Organizations.Services
{
    public interface IWardenService
    {
        Task CreateWardenAsync(Guid wardenId, string name, Guid organizationId, string userId, bool enabled);
        Task DeleteWardenAsync(Guid wardenId, Guid organizationId, string userId);
        Task<bool> HasAccessAsync(string userId, Guid organizationId, Guid wardenId);
    }
}