using System;

namespace consent_api.Models
{
    public class ConsentResult
    {
        public Guid upn { get; set; }
        public Guid id { get; set; }
        public string msg { get; set; }
        public string tempId { get; set; }
    }
}
