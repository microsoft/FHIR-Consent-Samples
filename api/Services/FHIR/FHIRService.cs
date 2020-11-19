using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace consent_api.Services.FHIR
{
    public class FHIRService : BaseFHIRervice
    {
        const string CONSENTURL = "/Consent/{0}";

        public async Task<JObject> GetPatient(string PatientID)
        {
            string urlExt = "/Patient/" + PatientID;
            JObject json = await RunAsync(urlExt, HttpMethodType.Get, null);
            return json;
        }
        public async Task<JObject> GetConsent(string consentId, string upn)
        {
            string url = String.Format(CONSENTURL, consentId);
            JObject json = await RunAsync(url, HttpMethodType.Get, null);

            return json;
        }

        public async void UpdateConsent(string consentId, string upn, string isActive)
        {
            string url = String.Format(CONSENTURL, consentId);
            JObject consent = await RunAsync(url, HttpMethodType.Get, null);
            consent["status"] = isActive == "true" ? "active" : "inactive";

            await RunAsync(url, HttpMethodType.Put, new StringContent(consent.ToString()));
        }
    }
}
