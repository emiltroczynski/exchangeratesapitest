using NUnit.Framework;
using System;
using System.Net;
using TaskFromGain.Helpers;
using TaskFromGain.Model;
using TechTalk.SpecFlow;

namespace TaskFromGain.Steps
{
    [Binding]
    class ThenSteps
    {
        private readonly ResponseContext responseContext;

        public ThenSteps(ResponseContext responseContext)
        {
            this.responseContext = responseContext;
        }
        [Then(@"I receive response with ""(.*)"" currency and (.*) exchange rates")]
        public void ThenIReceiveResponseWithCurrencyAndExchangeRates(string currency, int exchangeRates)
        {
            ForeignExchangeRates expectedJson = new ForeignExchangeRates
            {
                BaseCurrency = currency,
                ExchangeDate = DateHelper.GetLastBusinessDay(DateTime.Now),
            };

            ForeignExchangeRates actualJson = new ForeignExchangeRates(responseContext.responseContent);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, responseContext.httpStatusCode);
                Assert.AreEqual(expectedJson.BaseCurrency, actualJson.BaseCurrency, "BaseCurrency is not valid");
                Assert.AreEqual(expectedJson.ExchangeDate, actualJson.ExchangeDate, "ExchangeDate is not valid");
                Assert.AreEqual(exchangeRates, actualJson.Rates.GetRatesCount(), "Numbers of rates are not equal");
            });
        }

        [Then(@"I receive response with ""(.*)"" currency and (.*) exchange rates and with ""(.*)"" date")]
        public void ThenIReceiveResponseWithCurrencyAndExchangeRates(string currency, int exchangeRates, string date)
        {
            int[] validDate = Array.ConvertAll(date.Split('-'), int.Parse);

            ForeignExchangeRates expectedJson = new ForeignExchangeRates
            {
                BaseCurrency = currency,
                ExchangeDate = new DateTime(validDate[0], validDate[1], validDate[2])
            };

            ForeignExchangeRates actualJson = new ForeignExchangeRates(responseContext.responseContent);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, responseContext.httpStatusCode);
                Assert.AreEqual(expectedJson.BaseCurrency, actualJson.BaseCurrency, "BaseCurrency is not valid");
                Assert.AreEqual(expectedJson.ExchangeDate, actualJson.ExchangeDate, "ExchangeDate is not valid");
                Assert.AreEqual(exchangeRates, actualJson.Rates.GetRatesCount(), "Numbers of rates are not equal");
            });
        }

        [Then(@"I receive error message: ""(.*)""")]
        public void ThenIReceiveErrorMessage(string expectedMessage)
        {
            Error expectedError = new Error
            {
                ErrorMessage = expectedMessage
            };

            Error actualError = new Error(responseContext.responseContent);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, responseContext.httpStatusCode);
                Assert.AreEqual(expectedError.ErrorMessage, actualError.ErrorMessage, "Error message is not valid");
            });
        }

        [Then(@"I receive error message with ""(.*)"" currency and latest date")]
        public void ThenIReceiveErrorMessageWithCurrencyAndLatestDate(string currencies)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string expectedMessage = "Symbols '" + currencies +"' are invalid for date " + date + ".";

            Error expectedError = new Error
            {
                ErrorMessage = expectedMessage
            };

            Error actualError = new Error(responseContext.responseContent);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, responseContext.httpStatusCode);
                Assert.AreEqual(expectedError.ErrorMessage, actualError.ErrorMessage, "Error message is not valid");
            });
        }
    }
}
