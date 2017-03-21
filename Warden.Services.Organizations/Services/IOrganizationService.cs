using System;
using System.Threading.Tasks;
using Warden.Common.Types;
using Warden.Services.Organizations.Domain;
using Warden.Services.Organizations.Queries;

namespace Warden.Services.Organizations.Services
{
    public interface IOrganizationService
    {
        Task<Maybe<Organization>> GetAsync(Guid id);
        Task<Maybe<Organization>> GetAsync(string userId, Guid organizationId);
        Task<Maybe<PagedResult<Organization>>> BrowseAsync(BrowseOrganizations query);
        Task UpdateAsync(Guid id, string name, string userId);
        Task CreateAsync(Guid id, string userId, string name, string description = "");
        Task CreateDefaultAsync(Guid id, string userId);
        Task DeleteAsync(Guid id, string userId);
        Task AssignUserAsync(Guid organizationId, string userId, string email, string role);
        Task UnassignUserAsync(Guid organizationId, string userId);
        string DefaultOrganizationName { get; }
    }
}