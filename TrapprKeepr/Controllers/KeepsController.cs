namespace TrapprKeepr.Controllers;

[ApiController]
[Route("api/keeps")]

public class KeepsController : ControllerBase
{
    private readonly KeepsService _keeService;
    private readonly Auth0Provider _auth0;

    public KeepsController(KeepsService keeService, Auth0Provider auth0)
    {
        _keeService = keeService;
        _auth0 = auth0;
    }

    [Authorize]
    [HttpPost]
    // STUB Create Keep
    public async Task<ActionResult<Keep>> Create([FromBody] Keep keepData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            keepData.CreatorId = userInfo.Id;
            Keep newKeep = _keeService.Create(keepData);
            return Ok(newKeep);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    // STUB Get Keep by Id
    [HttpGet("{keepId}")]
    public async Task<ActionResult<Keep>> GetKeepById(int keepId, string userId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            // string userId = userInfo.Id; - causes error
            Keep keep = _keeService.GetKeepById(keepId, userId);
            return Ok(keep);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    // STUB Get All Keeps
    [HttpGet]
    public ActionResult<List<Keep>> GetAllKeeps()
    {
        try
        {
            List<Keep> keeps = _keeService.GetAllKeeps();
            return Ok(keeps);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    // STUB EDIT Keep
    [Authorize]
    [HttpPut("{keepId}")]
    public async Task<ActionResult<Keep>> EditKeep([FromBody] Keep keepData, int keepId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            Keep edited = _keeService.EditKeep(keepData, keepId, userInfo.Id);
            return Ok(edited);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    // STUB DELETE Keep - Cannot implicitly convert type '(TrapprKeepr.Models.Keep, string)' to 'TrapprKeepr.Models.Keep'CS0029
    [Authorize]
    [HttpDelete("{keepId}")]
    public async Task<ActionResult<string>> DeleteKeep(int keepId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            _keeService.DeleteKeep(keepId, userInfo.Id);
            string message = "successfully deleted";
            return message;
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }


}
