using Microsoft.AspNetCore.Mvc;
using Hl7.Fhir.Model;
using Newtonsoft.Json;
using consent_api.Services.FHIR;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace consent_api.Controllers
{
    [Route("api/consents")]
    [ApiController]
    public class ConsentController : ControllerBase
    {
        FHIRService fs = new FHIRService();

        // GET: api/consent
        [HttpGet]
        public async Task<string> GetConsents([FromQuery] string id, [FromQuery] string upn)
        {
            var fhirconsents = await fs.GetConsent(id, "0");
            return fhirconsents.ToString(); ;
        }

<<<<<<< HEAD
=======
        // GET: api/consent
        [HttpPut]
        public void UpdateConsents([FromQuery] string id, [FromQuery] string upn, [FromQuery] string isActive)
        {
            fs.UpdateConsent(id, "0", isActive);
        }

>>>>>>> 7d2349e... updated the put function but it's not changing the value
        // POST api/<ConsentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        //// PUT api/<ConsentController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ConsentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    [Route("api/patient")]
    [ApiController]
    public class PatientController
    {
        [HttpGet]
        public string GetPatient([FromQuery] string id, [FromQuery] string upn)
        {
            Patient p = new Patient();
            return (JsonConvert.SerializeObject(p));
        }
    }
}
