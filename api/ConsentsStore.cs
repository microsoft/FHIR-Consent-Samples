using consent_api.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;

namespace consent_api
{
    public class ConsentsStore
    {
        public IEnumerable<FHIRModel> getMockedConsents()
        {
            return new List<FHIRModel>()
                    {
                        new FHIRModel() { id = "1", upn = "u1", status = true, msg = "Consent 1!" },
                        new FHIRModel() { id = "2", upn = "u2", status = true, msg = "Consent 2!" },
                        new FHIRModel() { id = "3", upn = "u1", status = true, msg = "Consent 3!" },
                        new FHIRModel() { id = "4", upn = "u2", status = false, msg = "Consent 4!" }
                    };
        }

        public string getJsonConsents()
        {
            string json = "";

            try
            {
                using (StreamReader r = new StreamReader("Models/consent.json"))
                {
                    json = r.ReadToEnd();
                }
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            } 
            
            return json;
        }

        public List<Consent> getFHIRConsents()
        {
            return new List<Consent>()
            {
                new Consent() {
                    Id = "1",
                    Meta = new Meta ()
                    {
                        Security = new List<Coding>
                            {
                                new Coding()
                                {
                                    System = "https://microsoft.com/fhir/oid",
                                    Code = "upn1"
                                }
                            }
                    }
                }
            };
        }

        public string getUPNGuid()
        {
            return new Guid().ToString();
        }
        public string getConsentGuid()
        {
            return new Guid().ToString();
        }
    }
}
