using System;
using System.Reflection;
using AutoMapper;

namespace ICanHazDadJoke.Mapping;

public class MapperProfiles:Profile
{
    public MapperProfiles()
    {
        SourceMemberNamingConvention = LowerUnderscoreNamingConvention.Instance;
        DestinationMemberNamingConvention = PascalCaseNamingConvention.Instance;
        CreateMap<Service.RandomJoke, Dto.RandomJoke>();
        CreateMap<Service.SearchJoke, Dto.SearchJoke>();
        CreateMap<Service.DadJoke, Dto.DadJoke>();
        CreateMap<Dto.SearchJoke, Dto.ModSearchJoke>()
            .ForMember(m => m.Results, opt => opt.Ignore());
    }
}

