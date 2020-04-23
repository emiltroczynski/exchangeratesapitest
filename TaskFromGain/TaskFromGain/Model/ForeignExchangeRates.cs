using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace TaskFromGain.Model
{
    internal class ForeignExchangeRates
    {
        internal string BaseCurrency { set; get; }
        internal DateTime? ExchangeDate { set; get; }
        internal DateTime? StartAt { set; get; }
        internal DateTime? EndAt { set; get; }
        internal Curriencies Curriencies { set; get; }
        internal IList<RatesWithDays> RatesWithDays { set; get; }
        internal ForeignExchangeRates() { }

        internal ForeignExchangeRates(string responseContent)
        {
            JObject jobject = JObject.Parse(responseContent);
            BaseCurrency = jobject.GetValue("base").ToString();
            ExchangeDate = jobject["date"] != null ? jobject.GetValue("date").ToObject<DateTime>() : (DateTime?)null;
            StartAt = jobject["start_at"] != null ? jobject.GetValue("start_at").ToObject<DateTime>() : (DateTime?)null;
            EndAt = jobject["end_at"] != null ? jobject.GetValue("end_at").ToObject<DateTime>() : (DateTime?)null;
            Curriencies = JsonConvert.DeserializeObject<Curriencies>(jobject.GetValue("rates").ToString());

            if (StartAt != null)
            {
                RatesWithDays = PopulateRatesWithDays(jobject);
            }
        }

        private IList<RatesWithDays> PopulateRatesWithDays(JObject jobject)
        {
            IList<RatesWithDays> ratesWithDays = new List<RatesWithDays>();

            JObject rates = (JObject)jobject["rates"];
            foreach (var rate in rates)
            {
                RatesWithDays singleDay = new RatesWithDays
                {
                    DayOfExchange = rate.Key,
                    Curriencies = rate.Value.ToObject<Curriencies>()
                };
                ratesWithDays.Add(singleDay);
            }

            return ratesWithDays;
        }
    }
}
