using System.Collections.Generic;

namespace AutofacDemoConsole {
    public class PersonDto
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public IList<PersonAddressDto> Addresses { get; set; }
    }

    public class PersonAddressDto
    {
        public string Street { get; set; }
        public int PostalCode { get; set; }

        public string AddressFormatted { get; set; }
    }
}