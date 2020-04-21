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
                Assert.AreEqual(exchangeRates, actualJson.Curriencies.GetCurrienciesCount(), "Curriencies count is not equal");
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
                Assert.AreEqual(exchangeRates, actualJson.Curriencies.GetCurrienciesCount(), "Curriencies count is not equal");
            });
        }

        [Then(@"I receive response with ""(.*)"" start: ""(.*)"" end: ""(.*)"" and (.*) days")]
        public void ThenIReceiveResponseWithStartEndAndDays(string currency, string startDate, string endDate, int numberOfDays)
        {
            int[] startDateArray = Array.ConvertAll(startDate.Split('-'), int.Parse);
            int[] endDateArray = Array.ConvertAll(endDate.Split('-'), int.Parse);

            ForeignExchangeRates expectedJson = new ForeignExchangeRates
            {
                BaseCurrency = currency,
                StartAt = new DateTime(startDateArray[0], startDateArray[1], startDateArray[2]),
                EndAt = new DateTime(endDateArray[0], endDateArray[1], endDateArray[2]),
            };

            ForeignExchangeRates actualJson = new ForeignExchangeRates(responseContext.responseContent);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, responseContext.httpStatusCode);
                Assert.AreEqual(expectedJson.BaseCurrency, actualJson.BaseCurrency, "BaseCurrency is not valid");
                Assert.AreEqual(expectedJson.ExchangeDate, actualJson.ExchangeDate, "ExchangeDate is not valid");
                Assert.AreEqual(expectedJson.StartAt, actualJson.StartAt, "StartAt is not valid");
                Assert.AreEqual(expectedJson.EndAt, actualJson.EndAt, "EndAt is not valid");
                Assert.AreEqual(numberOfDays, actualJson.RatesWithDays.Count, "Days are not equal");
            });
        }

        [Then(@"I receive response with ""(.*)"" start: ""(.*)"" end: ""(.*)"" and (.*) currencies")]
        public void ThenIReceiveResponseWithStartEndAndCurrencies(string currency, string startDate, string endDate, int numberOfCurrencies)
        {
            int[] startDateArray = Array.ConvertAll(startDate.Split('-'), int.Parse);
            int[] endDateArray = Array.ConvertAll(endDate.Split('-'), int.Parse);

            ForeignExchangeRates expectedJson = new ForeignExchangeRates
            {
                BaseCurrency = currency,
                StartAt = new DateTime(startDateArray[0], startDateArray[1], startDateArray[2]),
                EndAt = new DateTime(endDateArray[0], endDateArray[1], endDateArray[2]),
            };

            ForeignExchangeRates actualJson = new ForeignExchangeRates(responseContext.responseContent);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, responseContext.httpStatusCode);
                Assert.AreEqual(expectedJson.BaseCurrency, actualJson.BaseCurrency, "BaseCurrency is not valid");
                Assert.AreEqual(expectedJson.ExchangeDate, actualJson.ExchangeDate, "ExchangeDate is not valid");
                Assert.AreEqual(expectedJson.StartAt, actualJson.StartAt, "StartAt is not valid");
                Assert.AreEqual(expectedJson.EndAt, actualJson.EndAt, "EndAt is not valid");
                Assert.AreEqual(numberOfCurrencies, actualJson.RatesWithDays.Count, "Days are not equal");
                Assert.AreEqual(numberOfCurrencies, actualJson.RatesWithDays[0].Curriencies.GetCurrienciesCount(), "Currencies for day 1 are not equal");
                Assert.AreEqual(numberOfCurrencies, actualJson.RatesWithDays[1].Curriencies.GetCurrienciesCount(), "Currencies for day 2 are not equal");
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

            ValidateErrorMessage(expectedError, actualError);
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

            ValidateErrorMessage(expectedError, actualError);
        }

        private void ValidateErrorMessage(Error expectedError, Error actualError)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, responseContext.httpStatusCode);
                Assert.AreEqual(expectedError.ErrorMessage, actualError.ErrorMessage, "Error message is not valid");
            });
        }
    }
}
