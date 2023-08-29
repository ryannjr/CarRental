namespace webapi.Models.Entities
{
    public class Address
    {
        public string streetName { get; set; }
        public int streetNumber { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string country { get; set; }
        public char role { get; set; }

        public Address(string streetName, int streetNumber, string city, string state, string zipCode, string country, char role)
        {
            this.streetName = streetName;
            this.streetNumber = streetNumber;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
            this.country = country;
            this.role = role;
        }

    }
}
