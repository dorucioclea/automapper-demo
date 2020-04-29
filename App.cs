using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutofacDemoConsole.Models;
using AutofacDemoConsole.Services;
using System.Collections.Generic;
using AutoMapper;

namespace AutofacDemoConsole
{
    public class App
    {
        private readonly ITestService _testService;
        private readonly ILogger<App> _logger;
        private readonly AppSettings _config;

        private readonly IMapper _mapper;

        public App(ITestService testService,
            IOptions<AppSettings> config,
            IMapper mapper,
            ILogger<App> logger)
        {
            _testService = testService;
            _logger = logger;
            _config = config.Value;
            _mapper = mapper;
        }

        public void Run()
        {
            _logger.LogInformation($"This is a console application for {_config.ConsoleTitle}");
            _testService.Run();

            var person = new Person
            {
                Addresses = new List<PersonAddress>
                {
                    new PersonAddress
                    {
                        IsPublic = false,
                        PostalCode = 400,
                        Street = "Some street"
                    },

                    new PersonAddress
                    {
                        IsPublic = true,
                        PostalCode = 4001,
                        Street = "Some street 4001"
                    },

                    new PersonAddress
                    {
                        IsPublic = true,
                        PostalCode = 4002,
                        Street = "Some street 4002"
                    }
                },

                Age = 22,
                Name = "Name"
            };

            var personDto = this._mapper.Map<PersonDto>(person);
            

            System.Console.ReadKey();
        }
    }
}
