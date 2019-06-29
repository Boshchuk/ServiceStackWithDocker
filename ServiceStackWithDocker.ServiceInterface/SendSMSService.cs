using ServiceStack;
using ServiceStackWithDocker.ServiceModel;

namespace ServiceStackWithDocker.ServiceInterface
{
    public class SendSMSService : Service
    {
        private ISmsSender SmsSender { get; set; }

        private IMobileCountryCodeResolver mccResolver { get; set; }

        public object Get(SendSms request)
        {
            var result = SmsSender.SendSms(request);

            var mcc = mccResolver.Resolve(request.To);

            var smsRecord = new Sms()
            {
                
            };

            return result;
        }
    }

    public interface IMobileCountryCodeResolver
    {
        string Resolve(string phoneNumber);
    }

    public class DbMccResolver : IMobileCountryCodeResolver
    {
        public string Resolve(string phoneNumber)
        {
            throw new System.NotImplementedException();
            // go to database and try found record
        }
    }
}