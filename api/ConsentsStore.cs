using consent_api.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IEnumerable<Consent> 
    }
}
