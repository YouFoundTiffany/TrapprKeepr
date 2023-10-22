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

  // // STUB Get User Profile
  // [HttpGet("profiles/{profileid}")]
  // public ActionResult<Profile> GetProfile(string id)
  // {
  //   try
  //   {
  //     return Ok(_accountService.GetProfile(id));
  //   }
  // catch (Exception error)
  // {
  //     return BadRequest(error.Message);
  // }
  // }

  // // STUB Get User Keeps
  // [HttpGet("{profileid}/keeps")]
  // public ActionResult<List<Keep>> GetUserKeeps(string id)
  // {
  //   try
  //   {
  //     return Ok(_accountService.GetUserKeeps(id));
  //   }
  // catch (Exception error)
  // {
  //     return BadRequest(error.Message);
  // }

  // }

  // // STUB Get User Vaults
  // [HttpGet("{profileid}/vaults")]
  // public ActionResult<List<Vault>> GetUserVaults(string id)
  // {
  //   try
  //   {
  //     return Ok(_accountService.GetUserVaults(id));
  //   }
  //   catch (Exception e)
  //   {
  //     return BadRequest(e.Message);
  //   }
  // }

  // STUB Get My Account persons Vaults
  [HttpGet("account/vaults")]
  public ActionResult<List<Vault>> GetUserVaults(string id)
  {
    try
    {
      return Ok(_accountService.GetUserVaults(id));
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }


  }
}
