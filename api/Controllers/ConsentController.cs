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
        public async Task<string> GetConsents([FromQuery] string id, [FromQuery] string upn)
        {
            if (string.IsNullOrEmpty(id)) { 
                id = "25d4f7c6-37c5-42c6-bf3a-7fbe124928d3";
                upn = "3050084d-dba9-4c35-8666-3e22c2764a4b";
            }
            
            var fhirconsents = await fs.GetConsent(id, upn);
            return fhirconsents.ToString(); ;
        }

        // GET: api/consent
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<string> UpdateConsents([FromQuery] string id, [FromQuery] string upn, [FromQuery] string active)
        {
            var result = await fs.UpdateConsent((id ?? "25d4f7c6-37c5-42c6-bf3a-7fbe124928d3"), (upn ?? "3050084d-dba9-4c35-8666-3e22c2764a4b"), active);
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
