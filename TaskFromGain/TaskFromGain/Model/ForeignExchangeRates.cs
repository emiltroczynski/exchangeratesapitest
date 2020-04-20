using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace TaskFromGain.Model
{
    internal class ForeignExchangeRates
    {
        internal string BaseCurrency { set; get; }
        internal DateTime ExchangeDate { set; get; }
        internal Rates Rates { set; get; }

        internal ForeignExchangeRates() { }

        internal ForeignExchangeRates(string responseContent)
        {
            JObject jobject = JObject.Parse(responseContent);

            BaseCurrency = jobject.GetValue("base").ToString();
            ExchangeDate = jobject.GetValue("date").ToObject<DateTime>();
            Rates = JsonConvert.DeserializeObject<Rates>(jobject.GetValue("rates").ToString());
        }
    }
}
