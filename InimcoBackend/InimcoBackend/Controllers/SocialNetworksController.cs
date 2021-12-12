using InimcoBackend.Entities.Enums;
using InimcoBackend.Models.SocialNetworks;
using Microsoft.AspNetCore.Mvc;

namespace InimcoBackend.Controllers
{
    [ApiController]
    [Route("api/socialnetworks")]
    public class SocialNetworksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<SocialNetworkRetrievalDto>> GetSupportedSocialNetworks()
        {
            return Ok(GetListOfSupportedSocialNetworks()); 
        }

        private IEnumerable<SocialNetworkRetrievalDto> GetListOfSupportedSocialNetworks()
        {
            // Could point to a social network repository if further functionality is necessary (CRUD)
            // for now it's only used to retrieve a pre-defined set so it's fine in the controller.
            foreach(SocialNetworkEnum network in Enum.GetValues(typeof(SocialNetworkEnum)))
            {
                yield return new SocialNetworkRetrievalDto(network);
            }
        }
    }
}
