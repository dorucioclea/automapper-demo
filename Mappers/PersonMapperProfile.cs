using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AutofacDemoConsole
{
    public class PersonMapperProfile : Profile
    {
        private readonly Func<PersonAddress, bool> AddressIsPublic = (address) => {
            return address.IsPublic;
        };
    
        private readonly ILogger<PersonMapperProfile> _logger;

        public PersonMapperProfile(ILogger<PersonMapperProfile> logger)
        {
            this._logger = logger;
            this._logger.LogInformation("Activated with dependency injected logger (could be anything else e.g. a db service)");

            CreateMap<Person, PersonDto>()
                .ForMember(
                        destination => destination.Age,
                        map => map.MapFrom(source => source.Age)
                    )
                .ForMember(
                    destination => destination.Addresses,
                    map => map.MapFrom(source => source.Addresses.Where(AddressIsPublic))
                ).ReverseMap();
        }
    }
}