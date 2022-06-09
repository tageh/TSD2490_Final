#nullable disable
using Gruppe11.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net.Http.Headers;


namespace Gruppe11.Models
{
    public class FrostAPI
    {

        public List<Observasjon> observasjoner = new List<Observasjon>();
        string sisteUken = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");

        public List<Observasjon> HentOvservasjoner(string bruker)
        {
            var client = new RestClient($"https://frost.met.no/observations/v0.jsonld?sources=SN27160&referencetime=R7%2F{sisteUken}T6%2F{sisteUken}T6%2FP1D&elements=air_temperature");

            var request = new RestRequest("", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("UserAgent", "HttpClientFactory-Sample");
            request.AddHeader("Authorization", "Basic YmY5ZjUxYTMtMjZkMi00ZTZlLWFhYmYtMjVhNmU1MmJhYWE3OmQ5OTkyNWU1LTc5NDgtNDMwMy1iMGI2LThiZmFmMmNjZDU3NQ==");

            var response = client.Execute(request);

            dynamic obj = JObject.Parse(response.Content);
            string dataVerdi = "";
            dataVerdi = obj.data.ToString();

            var deserializedDataValue = JsonConvert.DeserializeObject<List<Rootobject>>(dataVerdi);

            foreach (var o in deserializedDataValue)
            {
                var nyObservasjon = new Observasjon();
                nyObservasjon.Dato = o.ReferenceTime;
                nyObservasjon.Temperatur = o.Observations[0].Value;
                nyObservasjon.Bruker = bruker;
                observasjoner.Add(nyObservasjon);

            }

            return observasjoner;
        }
    }
}