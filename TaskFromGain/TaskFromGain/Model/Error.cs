using Newtonsoft.Json.Linq;

namespace TaskFromGain.Model
{
    class Error
    {
        internal string ErrorMessage { set; get; }

        internal Error() { }

        internal Error(string responseContent)
        {
            JObject jObject = JObject.Parse(responseContent);
            ErrorMessage = jObject.GetValue("error").ToString();
            //TODO: BadRequest can have also 'exception'
        }
    }
}
