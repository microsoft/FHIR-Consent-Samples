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
