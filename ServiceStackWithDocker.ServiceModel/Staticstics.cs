using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;

namespace ServiceStackWithDocker.ServiceModel
{
    [Route("/statistics")]
    public class Staticstics : IReturn<List<StatisticRecord>>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string MccList { get; set; }
    }

    public class StatisticRecord
    {
        public int Day { get; set; }
        public string Mcc { get; set; }
        public decimal PricePerSms { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
    }
}