using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace consent_api.Services.FHIR
{
    public class FHIRService : BaseFHIRervice
    {
        const string BASEURL = "/Consent";
        const string GET_CONSENT_URL = BASEURL + "?patient=Patient/{0}&_security={1}";
        const string UPDATE_CONSENT_URL = BASEURL + "?_id={0}&_security={1}";

        public async Task<JObject> GetPatient(string PatientID)
        {
            string urlExt = "/Patient/" + PatientID;
            JObject json = await RunAsync(urlExt, HttpMethodType.Get, null);
            return json;
        }
        public async Task<JObject> GetConsent(string patientId, string upn)
        {
            string url = String.Format(GET_CONSENT_URL, patientId, upn);
            JObject json = await RunAsync(url, HttpMethodType.Get, null);

            return json;
        }

        public async Task<JObject> UpdateConsent(string patientId, string upn, string active)
        {
            string url = String.Format(GET_CONSENT_URL, patientId, upn);
            JObject json = await RunAsync(url, HttpMethodType.Get, null);
            var consent = json["entry"][0]["resource"];
            consent["status"] = active == "true" ? "active" : "inactive";
            var consentId = consent["id"];
            var result = await RunAsync(String.Format(UPDATE_CONSENT_URL, consentId, upn), HttpMethodType.Put, new StringContent(consent.ToString()));

            return result;
        }

        public async Task<JObject> CreateConsent(string patientId, string upn)
        {
            JObject consent;
            using(StreamReader r = File.OpenText(Directory.GetCurrentDirectory() + "/Models/consent.json"))
            {
                string json = r.ReadToEnd();
                consent = JsonConvert.DeserializeObject<JObject>(json);
            }

            //var meta = new Meta()
            //{
            //    Security = new List<Coding>
            //                {
            //                    new Coding()
            //                    {
            //                        System = "https://microsoft.com/fhir/oid",
            //                        Code = "upn"
            //                    }
            //                }
            //};

            var codingObj = "{ 'System' : 'https://microsoft.com/fhir/oid', 'Code' : '" + upn + "' }";
        
            consent["status"] = "active";
            consent["patient"]["reference"] = "Patient/" + patientId;
            consent["meta"]["security"][0]["code"] = upn;

            var result = await RunAsync(String.Format(BASEURL), HttpMethodType.Post, new StringContent(consent.ToString()));

            return result;
        }
    }
}
