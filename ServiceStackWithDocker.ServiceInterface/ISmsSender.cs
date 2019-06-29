using ServiceStackWithDocker.ServiceModel;

namespace ServiceStackWithDocker.ServiceInterface
{
    public interface ISmsSender
    {
        State SendSms(SendSms smsToSend);
    }
}