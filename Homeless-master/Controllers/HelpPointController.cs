using Homeless.Authorization.Attributes;
using Homeless.Database.Models;
using Homeless.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Homeless.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelpPointController : ControllerBase
{
    private readonly IHelpPointRepository _helpPointRepository;

    public HelpPointController(IHelpPointRepository helpPointRepository)
    {
        _helpPointRepository = helpPointRepository;
    }

    [Authorize]
    [HttpGet]
    public IEnumerable<HelpPointModel> Get()
    {
        try
        {
            return _helpPointRepository.GetAll();
        }
        catch (Exception e)
        {
            return new List<HelpPointModel>();
        }
    }

    [Authorize]
    [HttpPost]
    public ActionResult<HomelessModel> Post(HelpPointModel homelessModel)
    {
        try
        {
            var newHomeless =  _helpPointRepository.Add(homelessModel);

            return Ok(newHomeless);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _helpPointRepository.Delete(id);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}