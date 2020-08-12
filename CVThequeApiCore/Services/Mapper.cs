using AutoMapper;
using CVTheque.api.Models;
using CVTheque.core.Models;
using CVThequeApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVThequeApiCore.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Level, LevelApi>();

            // Resource to Domain
            CreateMap<LevelApi, Level>();

            // Domain to Resource
            CreateMap<LanguageLevel, LanguageLevelApi>();

            // Resource to Domain
            CreateMap<LanguageLevelApi, LanguageLevel>();

            // Domain to Resource
            CreateMap<User, UserApi>();

            // Resource to Domain
            CreateMap<UserApi, User>();

            // Domain to Resource
            CreateMap<Role, RoleApi>();

            // Resource to Domain
            CreateMap<RoleApi, Role>();
        }
    }
}
