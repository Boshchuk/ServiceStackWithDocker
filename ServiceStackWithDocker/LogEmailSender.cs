using ServiceStackWithDocker.ServiceInterface;
using ServiceStackWithDocker.ServiceModel;

namespace ServiceStackWithDocker
{
    public class LogEmailSender : ISmsSender
    {
        public State SendSms(SendSms smsToSend)
        {
            throw new System.NotImplementedException();
            // todo: write something to log file
        }
    }
}