
using System.Collections.Generic;

namespace AutofacDemoConsole
{
    public class Person 
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public IList<PersonAddress> Addresses { get; set; }
    }

    public class PersonAddress
    {
        public bool IsPublic { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
    }
}