namespace webapi.Models.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public Address() { }
        public Address(Guid id, string streetName, int streetNumber, string city, string state, string zipCode, string country)
        {
            this.Id = id;
            this.StreetName = streetName;
            this.StreetNumber = streetNumber;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
            this.Country = country;
        }

    }
}
