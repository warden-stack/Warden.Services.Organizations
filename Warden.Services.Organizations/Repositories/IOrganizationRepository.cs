using System;
using System.Threading.Tasks;
using Warden.Common.Types;
using Warden.Services.Organizations.Domain;
using Warden.Services.Organizations.Queries;

namespace Warden.Services.Organizations.Repositories
{
    public interface IOrganizationRepository
    {
        Task<Maybe<Organization>> GetAsync(Guid id);
        Task<Maybe<PagedResult<Organization>>> BrowseAsync(BrowseOrganizations query);
        Task<Maybe<Organization>> GetAsync(string name, string ownerId);
        Task UpdateAsync(Organization organization);
        Task AddAsync(Organization organization);
        Task DeleteAsync(Organization organization);
    }
}