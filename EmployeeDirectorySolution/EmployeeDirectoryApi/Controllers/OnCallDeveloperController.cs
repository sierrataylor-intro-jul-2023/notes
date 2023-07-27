using EmployeeDirectoryApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectoryApi.Controllers
{
    public class OnCallDeveloperController : ControllerBase
    {
        private readonly ILookupOnCallDevelopers _oncallDeveloperLookup;

        public OnCallDeveloperController(ILookupOnCallDevelopers developerLookup)
        {
            _oncallDeveloperLookup = developerLookup;
        }

        [HttpGet("/on-call-developer")]
        public async Task<ActionResult> GetOnCallDeveloper()
        {
            OnCallDeveloperResponseModel response = await _oncallDeveloperLookup.OnCallDeveloperLookup();




            return Ok(response);
        }
    }
}
