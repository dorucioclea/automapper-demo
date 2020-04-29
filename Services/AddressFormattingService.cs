using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutofacDemoConsole.Models;

namespace AutofacDemoConsole.Services
{
    public interface IAddressFormattingService
    {
        string Format(PersonAddress address);
    }

    public class AddressFormattingService : IAddressFormattingService
    {
        private readonly ILogger<TestService> _logger;
        private readonly AppSettings _config;

        public AddressFormattingService(ILogger<TestService> logger,
            IOptions<AppSettings> config)
        {
            _logger = logger;
            _config = config.Value;
        }

        public string Format(PersonAddress address)
        {
            var addressFormatted = $"{address.Street}, PO {address.PostalCode}";
            _logger.LogWarning($"Formatting address to {addressFormatted}");
            return addressFormatted;
        }
    }
}
