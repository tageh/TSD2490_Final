﻿#nullable disable
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Gruppe11.Models;

namespace Gruppe11.Data.Services
{
    public class FrostAPIService
    {
        public List<Observasjon> observasjoner = new List<Observasjon>();
        private readonly string sisteSyvDager = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");

        public async Task<List<Observasjon>> HentObservasjoner()
        {
            var client = new RestClient($"https://frost.met.no/observations/v0.jsonld?sources=SN27160&referencetime=R7%2F{sisteSyvDager}T12%2F{sisteSyvDager}T12%2FP1D&elements=air_temperature");

            var request = new RestRequest("", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("UserAgent", "HttpClientFactory-Sample");
            request.AddHeader("Authorization", "Basic YmY5ZjUxYTMtMjZkMi00ZTZlLWFhYmYtMjVhNmU1MmJhYWE3OmQ5OTkyNWU1LTc5NDgtNDMwMy1iMGI2LThiZmFmMmNjZDU3NQ==");

            var response = await client.ExecuteAsync(request);

            //Behandling av JSON-respons
            dynamic obj = JObject.Parse(response.Content);
            string dataVerdi = obj.data.ToString();

            var deserializedDataValue = JsonConvert.DeserializeObject<List<Rootobject>>(dataVerdi);

            observasjoner.Clear();

            foreach (var o in deserializedDataValue)
            {
                var nyObservasjon = new Observasjon();
                nyObservasjon.Dato = o.ReferenceTime;
                nyObservasjon.Temperatur = o.Observations[0].Value;
                observasjoner.Add(nyObservasjon);
            }
            return observasjoner;
        }
    }
}