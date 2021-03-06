using System;
using Warden.Common.Queries;

namespace Warden.Services.Organizations.Queries
{
    public class GetOrganization : IAuthenticatedQuery
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
    }
}