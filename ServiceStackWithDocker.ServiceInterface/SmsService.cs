using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack;
using ServiceStack.OrmLite;
using ServiceStackWithDocker.ServiceModel;

namespace ServiceStackWithDocker.ServiceInterface
{
    public class SmsService : Service
    {
        public static Sms[] SeedData = {
            new Sms
            {
                Id = 1,
                MobileCountryCode = "262",
                From = "+4917421293388",
                State = State.Success,
                To = "+4917421293399",
                DateTime = new DateTime(2019, 6, 29),
                Price = 0.055m
            },
            new Sms
            {
                Id = 2,
                MobileCountryCode = "232",
                From = "+4317421293388",
                State = State.Success,
                To = "+4317421293399",
                DateTime = new DateTime(2019, 6, 29),
                Price = 0.053m
            },
            new Sms
            {
                Id = 3,
                MobileCountryCode = "232",
                From = "+4317421293399",
                State = State.Success,
                To = "+4317421293388",
                DateTime = new DateTime(2019, 6, 30),
                Price = 0.053m
            },
            new Sms
            {
                Id = 4,
                MobileCountryCode = "232",
                From = "+4317421293399",
                State = State.Failed,
                To = "+4317421293377",
                DateTime = new DateTime(2019, 6, 30),
                Price = 0.053m
            },
            new Sms
            {
                Id = 5,
                MobileCountryCode = "232",
                From = "+4317421293399",
                State = State.Success,
                To = "+4317421293366",
                DateTime = new DateTime(2019, 6, 30),
                Price = 0.053m
            }
        };

        private ISmsSender SmsSender { get; set; }

        private ICountryCodeResolver CountryCodeResolver { get; set; }

        public object Get(SendSms request)
        {
            // we will mark faled all exceptional send sms requests
            var state = State.Success;

            if (request.To.IsNullOrEmpty())
            {
                state = State.Failed;
            }

            if (request.From.IsNullOrEmpty())
            {
                state = State.Failed;
            }

            if (state != State.Success)
            {
                return state;
            }

            var result = SmsSender.SendSms(request);

            var country = FindCountry(request.To);

            var smsRecord = new Sms
            {
                From = request.From,
                To = request.To,
                DateTime = DateTime.UtcNow,
                MobileCountryCode = country.MobileCountryCode,
                Price = country.PricePerSMS,
                State = result
            };

            Db.Insert<Sms>(smsRecord);
            return result;
        }

        public object Get(SentSms request)
        {
            if (request.DateTimeTo.Ticks == 0)
            {
                request.DateTimeTo = DateTime.MaxValue;
            }
            var expression = Db.From<Sms>()
              //  .Where(s => (s.DateTime.Ticks >= request.DateTimeFrom.Ticks && s.DateTime.Ticks <= request.DateTimeTo.Ticks))
                .Skip(request.Skip)
                .Take(request.Take)
              //.Select(x=>new {x, Total = Sql.Count("*") })
                ;

            var expressionResult = Db.Select(expression);

            var countExpression = Db.From<Sms>().Select("COUNT(*)");
            var totalCount = Db.Select<int>(countExpression).First();


            return new SentSmsResponse
            {
                TotalCoint = totalCount,
                Items = expressionResult
            };
        }

        private Country FindCountry(string phoneNumber)
        {
            if (phoneNumber.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            var countryCode = CountryCodeResolver.Resolve(phoneNumber);

            var expression = Db.From<Country>()
                .Where(c => c.CountryCode == countryCode);

            var country = Db.Select(expression).FirstOrDefault();

            return country;
        }
    }
}