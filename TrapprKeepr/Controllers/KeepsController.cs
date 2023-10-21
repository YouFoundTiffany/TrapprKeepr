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
    public ActionResult<Keep> GetKeepById(int keepId)
    {
        try
        {
            Keep keep = _keeService.GetKeepById(keepId);
            return Ok(keep);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
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
    [HttpPut("{keepId}")]
    public ActionResult<Keep> EditKeep(int keepId, [FromBody] Keep keepData)
    {
        try
        {
            _keeService.EditKeep(keepId, keepData);
            return Ok(keepData);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    // STUB DELETE Keep
    [HttpDelete("{keepId}")]
    public ActionResult<string> DeleteKeep(int keepId)
    {
        try
        {
            Keep keep = _keeService.DeleteKeep(keepId);

            return Ok($"{keep.Name} was deleted");
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

}