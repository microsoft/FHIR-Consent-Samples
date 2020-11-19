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
        const string CONSENT_URL = "/Consent?patient=Patient/{0}&_security={1}";
        const string BUNDLE_URL = "/Bundle?patient=Patient/{0}&_security={1}";

        public async Task<JObject> GetPatient(string PatientID)
        {
            string urlExt = "/Patient/" + PatientID;
            JObject json = await RunAsync(urlExt, HttpMethodType.Get, null);
            return json;
        }
        public async Task<JObject> GetConsent(string patientId, string upn)
        {
            string url = String.Format(CONSENT_URL, patientId, upn);
            JObject json = await RunAsync(url, HttpMethodType.Get, null);

            return json;
        }

        public async Task<JObject> UpdateConsent(string patientId, string upn, string isActive)
        {
            string url = String.Format(CONSENT_URL, patientId, upn);
            JObject consent = await RunAsync(url, HttpMethodType.Get, null);
            consent["entry"][0]["resource"]["status"] = isActive == "true" ? "active" : "inactive";

            var json = await RunAsync(String.Format(BUNDLE_URL, patientId, upn), HttpMethodType.Put, new StringContent(consent.ToString()));

            return json;
        }
    }
}
