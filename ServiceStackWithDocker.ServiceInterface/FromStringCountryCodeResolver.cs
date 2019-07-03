using ServiceStack;
using System;

namespace ServiceStackWithDocker.ServiceInterface
{
    public class FromStringCountryCodeResolver : ICountryCodeResolver
    {
        public string Resolve(string phoneNumber)
        {
            if (phoneNumber.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            var countryCode = phoneNumber.Substring(0, 2);

            return countryCode;
        }
    }
}