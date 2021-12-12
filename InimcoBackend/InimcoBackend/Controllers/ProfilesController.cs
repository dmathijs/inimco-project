
using AutoMapper;
using InimcoBackend.Models;
using InimcoBackend.Models.ProfileRetrieval;
using InimcoBackend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InimcoBackend.Controllers
{
    [ApiController]
    [Route("api/profiles")]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;

        public ProfilesController(IProfileRepository profileRepository, IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }

        [HttpGet("{id:guid:required}", Name = "GetProfile")]
        public ActionResult<ProfileWrapperRetrievalDto> GetProfile(Guid id)
        {
            var profile = _profileRepository.Retrieve(id);

            if (profile == null)
                return NotFound();

            var response = _mapper.Map<ProfileWrapperRetrievalDto>(profile);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ProfileRetrievalDto>> AddProfileAsync([FromBody]ProfileCreateDto profile) 
        {
            if (!ModelState.IsValid) return BadRequest();

            var mappedProfile = _mapper.Map<Entities.Profile>(profile);

            var storedProfile = await _profileRepository.StoreAsync(mappedProfile);

            if (storedProfile == null) return Problem("Couldn't persist profile to store, try again later", statusCode:500); 

            var model = _mapper.Map<ProfileWrapperRetrievalDto>(storedProfile);

            return CreatedAtRoute("GetProfile", new { id = model.OriginalProfile?.Guid }, model);
        }
    }
}
