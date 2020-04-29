using AutofacDemoConsole.Services;
using AutoMapper;

namespace AutofacDemoConsole
{
    public class AddressFormattingResolver : IValueResolver<PersonAddress, PersonAddressDto, string>
    {
        private readonly IAddressFormattingService _formattingService;
        public AddressFormattingResolver(IAddressFormattingService formattingService)
        {
            this._formattingService = formattingService;
        }

        string IValueResolver<PersonAddress, PersonAddressDto, string>.Resolve(PersonAddress source, PersonAddressDto destination, string destMember, ResolutionContext context)
        {
            var formattedValue = this._formattingService.Format(source);

            return formattedValue;
        }
    }
}