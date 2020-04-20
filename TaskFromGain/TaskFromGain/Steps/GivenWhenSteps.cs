using RestSharp;
using TaskFromGain.Helpers;
using TechTalk.SpecFlow;

namespace TaskFromGain.Steps
{
    [Binding]
    class GivenWhenSteps
    {
        private RestClient client;
        private RestRequest restRequest;
        private IRestResponse response;
        private readonly ResponseContext actualResponse;

        public GivenWhenSteps(ResponseContext responseContext)
        {
            this.actualResponse = responseContext;
        }

        [Given(@"I prepare request with ""(.*)"" parameter")]
        public void GivenIPrepareRequestWithParameter(string parameter)
        {
            client = new RestClient("https://api.exchangeratesapi.io/");
            restRequest = new RestRequest(parameter);
        }

        [When(@"I send request")]
        public void WhenISendRequest()
        {
            response = client.Get(restRequest);
            actualResponse.httpStatusCode = response.StatusCode;
            actualResponse.responseContent = response.Content;
        }
    }
}
