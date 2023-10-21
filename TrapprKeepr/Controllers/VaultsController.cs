namespace TrapprKeepr.Controllers;

[ApiController]
[Route("api/vaults")]

public class VaultsController : ControllerBase
{
    private readonly VaultsService _vaultsService;
    private readonly Auth0Provider _auth0;

    public VaultsController(VaultsService vaultsService, Auth0Provider auth0)
    {
        _vaultsService = vaultsService;
        _auth0 = auth0;
    }

    [Authorize]
    [HttpPost]

    public async Task<ActionResult<Vault>> Create([FromBody] Vault vaultData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            vaultData.CreatorId = userInfo.Id;
            Vault newVault = _vaultsService.Create(vaultData);
            return newVault;
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }


}