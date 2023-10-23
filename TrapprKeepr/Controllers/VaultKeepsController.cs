namespace TrapprKeepr.Controllers;

[ApiController]
[Route("api/vaultkeeps")]

public class VaultKeepsController : ControllerBase
{
    private readonly VaultKeepsService _vkeService;
    private readonly Auth0Provider _auth0;

    public VaultKeepsController(VaultKeepsService vkeService, Auth0Provider auth0)
    {
        _vkeService = vkeService;
        _auth0 = auth0;
    }

    [Authorize]
    [HttpPost]
    // STUB Create VaultKeep
    public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep vaultKeepData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            vaultKeepData.CreatorId = userInfo.Id;
            VaultKeep newVaultKeep = _vkeService.Create(vaultKeepData);
            return Ok(newVaultKeep);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    // STUB Get VaultKeep by Id
    [HttpGet("{vaultkeepid}")]
    public async Task<ActionResult<VaultKeep>> GetVaultKeepById(int vaultKeepId, string userId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            // string userId = userInfo?.Id;
            VaultKeep vaultKeep = _vkeService.GetVaultKeepById(vaultKeepId, userId);
            return Ok(vaultKeep);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    // STUB Get All Keeps
    [HttpGet]
    public ActionResult<List<VaultKeep>> GetAllVaultVaultKeeps()
    {
        try
        {
            List<VaultKeep> vaultKeeps = _vkeService.GetAllVaultKeeps();
            return Ok(vaultKeeps);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    // STUB DELETE Keep - Cannot implicitly convert type '(TrapprKeepr.Models.Keep, string)' to 'TrapprKeepr.Models.Keep'CS0029
    [Authorize]
    [HttpDelete("{vaultkeepid}")]
    public async Task<ActionResult<string>> DeleteVaultKeep(int vaultKeepId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            _vkeService.DeleteVaultKeep(vaultKeepId, userInfo.Id);
            string message = "successfully deleted";
            return Ok(message);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
// STUB EDIT Keep
// [Authorize]
// [HttpPut("{vaultKeepId}")]
// public async Task<ActionResult<Keep>> EditKeep([FromBody] Keep vaultKeepData, int vaultKeepId)
// {
//     try
//     {
//         Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
//         Keep edited = _vkeService.EditKeep(keepData, vaultKeepId, userInfo.Id);
//         return Ok(edited);
//     }
//     catch (Exception error)
//     {
//         return BadRequest(error.Message);
//     }
// }