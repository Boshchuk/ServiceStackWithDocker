using System.Collections.Generic;
using System.Linq;
using ServiceStack;
using ServiceStack.OrmLite;
using ServiceStackWithDocker.ServiceModel;

namespace ServiceStackWithDocker.ServiceInterface
{
    public class StatisticsService : Service
    {
        public object Get(Staticstics request)
        {
            var mccList = request.MccList.Split(',');

            var expression = Db.From<Sms>()
                .Where(s => (s.DateTime >= request.DateFrom && s.DateTime <= request.DateTo))
                .Where(m => mccList.Contains(m.MobileCountryCode))
                .Where(v=>v.State == State.Success);

            var expressionResult = Db.Select(expression)
                .GroupBy(g => new {g.MobileCountryCode, g.DateTime.DayOfYear});
              
            var result = new List<StatisticRecord>();

            foreach (var grouping in expressionResult)
            {
                result.Add(new StatisticRecord
                {
                    Count = grouping.Count(),
                    Day = grouping.Key.DayOfYear,
                    Mcc = grouping.Key.MobileCountryCode,
                    TotalPrice = grouping.Sum(x=>x.Price),
                    PricePerSms = grouping.First().Price
                });
            }

            return result;
        }
    }
}