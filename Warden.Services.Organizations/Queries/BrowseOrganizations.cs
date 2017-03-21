using Warden.Common.Queries;

namespace Warden.Services.Organizations.Queries
{
    public class BrowseOrganizations : AuthenticatedPagedQueryBase
    {
        public string OwnerId { get; set; }
    }
}