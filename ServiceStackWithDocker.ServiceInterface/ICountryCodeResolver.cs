namespace ServiceStackWithDocker.ServiceInterface
{
    public interface ICountryCodeResolver
    {
        string Resolve(string phoneNumber);
    }
}