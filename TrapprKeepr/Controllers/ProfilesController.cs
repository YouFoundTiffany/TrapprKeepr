// PROFILES CONTROLLER
namespace TrapprKeepr.Controllers;

[ApiController]
[Route("api/profiles")]

public class ProfilesController : ControllerBase
{
    private readonly AccountService _aService;
    private readonly Auth0Provider _auth0Provider;
    private readonly VaultsService _vService;
    public ProfilesController(AccountService aService, Auth0Provider auth0Provider, VaultsService vService)

    {
        _aService = aService;
        _vService = vService;
        _auth0Provider = auth0Provider;
    }

    // STUB Get THIS User Profile
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

    // STUB Get THIS User Keeps
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

    // WE WANT VAULTS
    // Get another users vaults using their profile/account ID :D
    // ✅ Enpoint is correct - per Postman
    //✉️ SENDING TO VAULTS SERVICE
    [HttpGet("{profileId}/vaults")]
    public async Task<ActionResult<List<Vault>>> GetVaultsByProfileId(string profileId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);

            // Fetching vaults for the provided profileId, using the logged-in user's Id as requesterId
            List<Vault> vaults = _vService.GetVaultsByProfileId(profileId, userInfo?.Id);

            return Ok(vaults);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}




