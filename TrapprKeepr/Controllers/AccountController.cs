// ACCOUNTS CONTROLLER
namespace TrapprKeepr.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly VaultsService _vService;
  private readonly Auth0Provider _auth0Provider;
  public AccountController(AccountService accountService, Auth0Provider auth0Provider, VaultsService vService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _vService = vService;
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

  // ACCOUNTS!!!!!!! TO VAULTS SERVICE
  // STUB Get My Account Vaults
  [HttpGet("vaults")]
  [Authorize]
  public async Task<ActionResult<List<Vault>>> GetVaultsByAccountId()
  {
    try
    {
      Account account = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      if (account == null) throw new Exception($"Unable to find {account}");

      List<Vault> myVaults = _vService.GetVaultsByAccountId(account?.Id);

      return Ok(myVaults);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}
