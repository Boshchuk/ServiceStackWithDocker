using ServiceStack;
using ServiceStack.OrmLite;
using ServiceStackWithDocker.ServiceModel;

namespace ServiceStackWithDocker.ServiceInterface
{
    public class CountriesService : Service
    {
        public static Country[] SeedData = new[] {
            new Country() {
                Id = 1,
                Name = "Germany",
                MobileCountryCode = 262,
                CountryCode = 49,
                PricePerSMS = 0.055m
            },
             new Country() {
                Id = 2,
                Name = "Austria",
                MobileCountryCode = 232,
                CountryCode = 43,
                PricePerSMS = 0.053m
            },
             new Country() {
                Id = 3,
                Name = "Poland",
                MobileCountryCode = 260,
                CountryCode = 48,
                PricePerSMS = 0.032m
            },
        };

        public object Get(GetCountries request)
        {
            return Db.Select<Country>();
            //return new GetCountriesResponse
            //{
            //    Results = Db.Select<Country>()
            //};
        }

    }
}
