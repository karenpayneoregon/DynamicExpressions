namespace CustomersByCountry.Classes
{
    public class CustomerCountries
    {
        public int CustomerIdentifier { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryName { get; set; }
        public override string ToString() => $"{CustomerIdentifier} - {CompanyName}";

    }
}