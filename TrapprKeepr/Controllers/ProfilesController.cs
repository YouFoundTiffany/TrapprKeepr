namespace TrapprKeepr.Controllers;

[ApiController]
[Route("api/profiles")]

public class ProfilesController : ControllerBase
{
    private readonly AccountService _aService;
    private readonly Auth0Provider _auth0Provider;
    public ProfilesController(AccountService aService, Auth0Provider auth0Provider)
    {
        _aService = aService;
        _auth0Provider = auth0Provider;
    }

    // STUB Get User Profile
    [HttpGet("{profileId}")]
    public ActionResult<Profile> GetProfileById(string profileId)
    {
        try
        {
            Profile profile = _aService.GetProfile(profileId);
            if (profile == null)
            {
                return NotFound("Profile not found");
            }
            return Ok(profile);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    // STUB Get User Keeps
    [HttpGet("{profileId}/keeps")]
    public ActionResult<List<Keep>> GetUserKeeps(string profileId)
    {
        try
        {
            return Ok(_aService.GetUserKeeps(profileId));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    // STUB Get User Vaults
    [HttpGet("{profileId}/vaults")]
    public ActionResult<List<Vault>> GetUserVaults(string profileId)
    {
        try
        {
            return Ok(_aService.GetUserVaults(profileId));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}