using System.Linq;
using AutoMapper;
using Warden.Services.Organizations.Domain;
using Warden.Services.Organizations.Shared.Dto;

namespace Warden.Services.Organizations.Framework
{
    public class AutoMapperConfig
    {
        public static IMapper InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Organization, OrganizationDto>()
                    .ForMember(x => x.Owner, x => x.MapFrom(p => p.Users.First(u => u.Role == "owner")));
                cfg.CreateMap<UserInOrganization, UserInOrganizationDto>();
                cfg.CreateMap<Domain.Warden, WardenDto>();
                cfg.CreateMap<Watcher, WardenDto>();
            });

            return config.CreateMapper();
        }
    }
}