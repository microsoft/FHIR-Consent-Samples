using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using consent_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace consent_api.Controllers
{
    [Route("api/consents")]
    [ApiController]
    public class ConsentController : ControllerBase
    {
        // GET: api/consent
        [HttpGet]
        public string GetConsents([FromQuery] string id, [FromQuery] string upn)
        {
            string jsonResult;
            List<Consent> consents = new ConsentsStore().getConsents().ToList();
            var consent = consents.FindAll(a => (a.id == id) && (a.upn == upn));
            jsonResult = JsonConvert.SerializeObject(new
            {
                results = consent
            });

            return jsonResult;
        }

        // POST api/<ConsentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ConsentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConsentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
