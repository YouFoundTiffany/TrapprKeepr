namespace TrapprKeepr.Controllers;

[ApiController]
[Route("api/vaults")]

public class VaultsController : ControllerBase
{
    private readonly VaultsService _vaultsService;
    private readonly VaultKeepsService _vkeService;
    private readonly Auth0Provider _auth0;

    public VaultsController(VaultsService vaultsService, KeepsService keeService, VaultKeepsService vkeService, Auth0Provider auth0)
    {
        _vaultsService = vaultsService;
        // _keeService = keeService;
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
    // STUB Get a single Vault the Vault's Id - Only Showing open to public and hiding privates.

    [HttpGet("{vaultId}")]
    public async Task<ActionResult<Vault>> GetVaultById(int vaultId)
    {
        // NOTE put ELVIS in the string userInfo?.Id because anyone who isn't logged in can and should still be able to get a vault by Id.
        try
        {
            // Profile userInfo = await _auth0.GetUserInfoAsync<Profile>(HttpContext);
            // List<Vault> vaults = _vaultsService.GetVaultById(vaultId, userInfo?.Id);
            // return Ok(vaults);


            Profile userInfo = await _auth0.GetUserInfoAsync<Profile>(HttpContext);
            string userId = userInfo?.Id;
            Vault vault = _vaultsService.GetVaultById(vaultId, userId);
            return Ok(vault);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    // // STUB Get All Vaults
    // [HttpGet]
    // public async Task<ActionResult<List<Vault>>> GetAllVaults()
    // {
    //     try
    //     {
    //         Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
    //         List<Vault> vaults = _vaultsService.GetAllVaults(userInfo?.Id);
    //         return Ok(vaults);
    //     }
    //     catch (Exception error)
    //     {
    //         return BadRequest(error.Message);
    //     }
    // }

    // [HttpGet]
    // public ActionResult<List<Vault>> GetAllVaults()
    // {
    //     try
    //     {
    //         List<Vault> vaults = _vaultsService.GetAllVaults();
    //         return Ok(vaults);
    //     }
    //     catch (Exception error)
    //     {
    //         return BadRequest(error.Message);
    //     }
    // }


    // STUB EDIT Vault
    [Authorize]
    [HttpPut("{vaultId}")]
    public async Task<ActionResult<Vault>> EditVault([FromBody] Vault vaultData, int vaultId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            Vault edited = _vaultsService.EditVault(vaultData, vaultId, userInfo.Id);
            return Ok(edited);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    // STUB DELETE Vault
    [Authorize]
    [HttpDelete("{vaultId}")]
    public async Task<ActionResult<string>> DeleteVault(int vaultId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            _vaultsService.DeleteVault(vaultId, userInfo.Id);
            string message = "successfully deleted";
            return Ok(message);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    // STUB Get VaultKeeps by Vault Id VIEW Model, many to many join continued
    // this should only works if the vault is not private
    // [Authorize]
    [HttpGet("{vaultId}/keeps")]
    public async Task<ActionResult<List<VaultKeepsViewModel>>> GetVaultKeepsByVaultId(int vaultId)
    {
        try
        {

            Profile userInfo = await _auth0.GetUserInfoAsync<Profile>(HttpContext);



            // string userId = userInfo?.Id;

            List<VaultKeepsViewModel> myKeeps = _vkeService.GetVaultKeepsByVaultId(vaultId, userInfo?.Id);

            return myKeeps;
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}