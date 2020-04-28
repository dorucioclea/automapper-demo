using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AutofacDemoConsole
{
    public class PersonAddressMapperProfile : Profile
    {
        private readonly ILogger<PersonAddressMapperProfile> _logger;

        public PersonAddressMapperProfile(ILogger<PersonAddressMapperProfile> logger)
        {
            this._logger = logger;
            this._logger.LogInformation("Activated with dependency injected logger (could be anything else e.g. a db service)");

            CreateMap<PersonAddress, PersonAddressDto>()
                .ForMember(
                        destination => destination.Street,
                        map => map.MapFrom(source => source.Street)
                    )
                .ForMember(
                    destination => destination.PostalCode,
                    map => map.MapFrom(source => source.PostalCode)
                )
                .ForMember(
                    destination => destination.AddressFormatted,
                    map => map.MapFrom<AddressFormattingResolver>()
                ).ReverseMap();
        }
    }
}