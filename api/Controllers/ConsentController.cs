using Microsoft.AspNetCore.Mvc;
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

        // GET: api/consent
        [HttpPut]
        public void UpdateConsents([FromQuery] string id, [FromQuery] string upn, [FromQuery] string isActive)
        {
            fs.UpdateConsent(id, "0", isActive);
        }

        // POST api/<ConsentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

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
        public async Task<string> GetPatient([FromQuery] string id, [FromQuery] string upn)
        {
            //GET consent for UPN 
            // parse CONSENT and make sure it's active
            // [make sure it's unexpired]
            //GET patient ID=$id
            FHIRService fs = new FHIRService();
            
            var fhirconsent = await fs.GetConsent("2501c216-ab84-4f12-9b69-69212f5f5638", "0");
            
            if (fhirconsent["status"].ToString().Equals("active")) {
                var patient = await fs.GetPatient(id);
                return patient.ToString();
            } else
            {
                return "401";
            }
        }
    }
}
