using AutoMapper;
using CVTheque.client.ViewModels;
using CVTheque.core.Models;
using CVTheque.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVTheque.Server.Services
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
            CreateMap<User, ViewUser>();

            // Resource to Domain
            CreateMap<ViewUser, User>();
        }
    }
}
