namespace TrapprKeepr.Controllers;

[ApiController]
[Route("api/vaults")]

public class VaultsController : ControllerBase
{
    private readonly VaultsService _vaultsService;
    private readonly KeepsService _keeService;
    private readonly VaultKeepsService _vkeService;
    private readonly Auth0Provider _auth0;

    public VaultsController(VaultsService vaultsService, KeepsService keeService, VaultKeepsService vkeService, Auth0Provider auth0)
    {
        _vaultsService = vaultsService;
        _keeService = keeService;
        _vkeService = vkeService;
        _auth0 = auth0;
    }

    [Authorize]
    [HttpPost]
    // STUB Create Vault
    public async Task<ActionResult<Vault>> Create([FromBody] Vault vaultData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            vaultData.CreatorId = userInfo.Id;
            Vault newVault = _vaultsService.Create(vaultData);
            return Ok(newVault);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    // STUB Get Vault by Id
    [HttpGet("{vaultId}")]
    public ActionResult<Vault> GetVaultById(int vaultId)
    {
        try
        {
            Vault vault = _vaultsService.GetVaultById(vaultId);
            return Ok(vault);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    // STUB Get All Vaults
    [HttpGet]
    public ActionResult<List<Vault>> GetAllVaults()
    {
        try
        {
            List<Vault> vaults = _vaultsService.GetAllVaults();
            return Ok(vaults);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    // STUB EDIT VAULT
    [Authorize]
    [HttpPut("{vaultId}")]
    public ActionResult<Vault> EditVault(int vaultId, [FromBody] Vault vaultData)
    {
        try
        {
            _vaultsService.EditVault(vaultId, vaultData);
            return Ok(vaultData);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    // STUB DELETE VAULT
    [Authorize]
    [HttpDelete("{vaultId}")]
    public ActionResult<string> DeleteVault(int vaultId)
    {
        try
        {
            Vault vault = _vaultsService.DeleteVault(vaultId);

            return Ok($"{vault.Name} was deleted");
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    // STUB Get KEEPS by Vault Id
    [HttpGet("{vaultId}/keeps")]
    public ActionResult<List<Keep>> GetKeepsByVaultId(int vaultId)
    {
        try
        {
            List<Keep> keeps = _keeService.GetKeepsByVaultId(vaultId);
            return keeps;
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    // STUB Get VAULT KEEPS by Vault Id
    [HttpGet("{vaultId}/keeps")]
    public ActionResult<List<VaultKeepsViewModel>> GetVaultKeepsByVaultId(int vaultId)
    {
        try
        {
            List<VaultKeepsViewModel> vaultKeeps = _vkeService.GetVaultKeepsByVaultId(vaultId);
            return _vkeService.GetVaultKeepsByVaultId(vaultId);

        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}