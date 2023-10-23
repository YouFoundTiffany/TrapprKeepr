namespace TrapprKeepr.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  public AccountController(AccountService accountService, Auth0Provider auth0Provider)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
  }

  // STUB GetOrCreateProfile
  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Account>> GetOrCreateProfile()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  // STUB Edit Account
  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  // STUB Get My Account Vaults
  [HttpGet("vaults")]
  public async Task<ActionResult<List<Vault>>> GetUserVaults()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> myVaults = _accountService.GetUserVaults(userInfo.Id);
      // return Ok(_accountService.GetOrCreateProfile(userInfo));
      return myVaults;
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}
