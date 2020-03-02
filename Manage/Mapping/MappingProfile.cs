using AutoMapper;
using Core.Models;
using Manage.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResource>();

            CreateMap<UserCreateResource, User>()
                .ForMember(d => d.AddedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(d => d.ModifiedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(d => d.AddedBy, opt => opt.MapFrom(src => "System"))
                .ForMember(d => d.Status, opt => opt.MapFrom(src => true))
                .ForMember(d => d.Token, opt => opt.MapFrom(src => Guid.NewGuid().ToString()));
        }
    }
}
