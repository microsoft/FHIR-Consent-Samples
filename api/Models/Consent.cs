using System;

namespace consent_api.Models
{
    public class Consent
    {
        public string id { get; set; }
        public string msg { get; set; }
        public bool status { get; set; }
        public string upn { get; set; }
    }
}
