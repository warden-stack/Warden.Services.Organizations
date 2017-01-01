using Warden.Common.Queries;

namespace Warden.Services.Organizations.Queries
{
    public class BrowseOrganizations : PagedQueryBase
    {
        public string UserId { get; set; }
        public string OwnerId { get; set; }
    }
}