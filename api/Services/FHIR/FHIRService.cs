﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace consent_api.Services.FHIR
{
    public class FHIRService : BaseFHIRervice
    {
        public async Task<JObject> GetPatient(string PatientID)
        {
            
            string urlExt = "/patient/"+PatientID;
            JObject json = await RunAsync(urlExt, HttpMethodType.Get, null);
            return json;
        }

    }
}