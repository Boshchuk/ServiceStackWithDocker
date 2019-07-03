using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace ServiceStackWithDocker.ServiceModel
{
    [Route("/sms/send")] 
    public class SendSms : IReturn<State>
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
    }

    [Route("/sms/sent")]
    public class SentSms : IReturn<SentSmsResponse>
    {
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }

    [DataContract]
    public class Sms
    {
        [AutoIncrement]
        public int Id { get; set; }

        [DataMember(Name = "dateTime")]
        public DateTime DateTime { get; set; }

        [DataMember(Name = "mcc")]
        public string MobileCountryCode { get; set; }

        [DataMember(Name = "from")]
        public string From { get; set; }

        [DataMember(Name = "to")]
        public string To { get; set; }

        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        [DataMember(Name = "state")]
        public State State { get; set; }
    }

    public class SentSmsResponse
    {
        public int TotalCoint { get; set; }
        public List<Sms> Items { get; set; }
    }

    
}