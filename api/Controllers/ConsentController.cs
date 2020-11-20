using Microsoft.AspNetCore.Mvc;
using consent_api.Services.FHIR;
using System.Threading.Tasks;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

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
        public async Task<string> GetConsents([FromQuery] string patientId, [FromQuery] string upn)
        {
            if (patientId == null || upn == null )
            {
                return "Please provide both the patientId, Upn parameters";
            }

            var fhirconsents = await fs.GetConsent(patientId, upn);
            return fhirconsents.ToString(); ;
        }

        // GET: api/consent
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<string> UpdateConsents([FromQuery] string patientId, [FromQuery] string upn, [FromQuery] string active)
        {
            if (patientId == null || upn == null || active == null)
            {
                return "Please provide all the required parameters (patientId, upn, and active state)";
            }

            var result = await fs.UpdateConsent(patientId, upn, active);
            return result.ToString();
        }

        // POST api/<ConsentController>
        [HttpPost]
        public async Task<string> Post([FromQuery] string patientId, [FromQuery] string upn)
        {
            var result = await fs.CreateConsent(patientId, upn);
            return result.ToString();
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
            
            var fhirconsent = await fs.GetConsent(id, upn);
            string isActive  = (string)fhirconsent.SelectToken("entry.[0].resource.status");
            if (string.IsNullOrEmpty(isActive))
            {
                isActive = "inActive";
            }
            
            if (isActive.Equals("active")) {
                var patient = await fs.GetPatient(id);
                return patient.ToString();
            } else
            {
                return "401 you don't have access or patient does not exsit";
            }
        }
    }
}
