using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;


namespace ServiceStackWithDocker.ServiceModel
{
    // To do it simplest for poco and dto same model is used
    [DataContract]
    public class Country
    {
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "mcc")]
        public int MobileCountryCode { get; set; }

        [DataMember(Name = "cc")]
        public int CountryCode { get; set; }

        [DataMember(Name = "pricePerSMS")]
        public decimal PricePerSMS { get; set; }
    }

    [Route("/countries", "GET")]
    public class GetCountries : IReturn<List<Country>> { }
}
