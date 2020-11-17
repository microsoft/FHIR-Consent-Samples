using Hl7.Fhir.Model;
using System;
using System.ComponentModel;

namespace consent_api.Models
{
    public class FHIRModel
    {
        public string id { get; set; }
        public string msg { get; set; }
        public bool status { get; set; }
        public string upn { get; set; }
    }
}
