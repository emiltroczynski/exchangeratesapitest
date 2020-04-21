using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

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
                RatesWithDays = create(jobject);
            }
        }

        private IList<RatesWithDays> create(JObject jobject)
        {
            IList<JToken> results = jobject["rates"].Children().Children().ToList();
            IList<RatesWithDays> searchResults = new List<RatesWithDays>();
            int index = 0;
            foreach (JToken result in results)
            {
                RatesWithDays ratesWithDays = new RatesWithDays
                {
                    Curriencies = result.ToObject<Curriencies>(),
                    DayOfExchange = (JObject.Parse(jobject.GetValue("rates").ToString()).Properties().Select(p => p.Name).ElementAt(index++))
                };

                searchResults.Add(ratesWithDays);
            }

            return searchResults;
        }
    }
}
