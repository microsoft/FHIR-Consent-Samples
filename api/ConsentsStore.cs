using consent_api.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace consent_api
{
    public class ConsentsStore
    {
        public IEnumerable<Consent> getConsents()
        {
            return new List<Consent>()
                    {
                        new Consent() { id = "1", upn = "u1", status = true, msg = "Consent 1!" },
                        new Consent() { id = "2", upn = "u2", status = true, msg = "Consent 2!" },
                        new Consent() { id = "3", upn = "u1", status = true, msg = "Consent 3!" },
                        new Consent() { id = "4", upn = "u2", status = false, msg = "Consent 4!" }
                    };
        }
    }
}
