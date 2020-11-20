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
        const string UPDATE_URL = "/Consent?id={0}&_security={1}";

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

        public async Task<JObject> UpdateConsent(string patientId, string upn, string active)
        {
            string url = String.Format(CONSENT_URL, patientId, upn);
            JObject json = await RunAsync(url, HttpMethodType.Get, null);
            var consent = json["entry"][0]["resource"];
            consent["status"] = active == "true" ? "active" : "inactive";
            var consentId = consent["id"];
            var result = await RunAsync(String.Format(UPDATE_URL, consentId, upn), HttpMethodType.Put, new StringContent(consent.ToString()));

            return result;
        }
    }
}
