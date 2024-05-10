using Homeless.Database.Models;
using Homeless.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Homeless.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomelessMessageController : ControllerBase
{
    private readonly IHomelessMessageRepository _homelessRepository;


    public HomelessMessageController(IHomelessMessageRepository homelessRepository)
    {
        _homelessRepository = homelessRepository;
    }

    [HttpGet]
    public IEnumerable<HomelessMessageModel> Get()
    {
        try
        {
            return _homelessRepository.GetAll();
        }
        catch (Exception e)
        {
            return new List<HomelessMessageModel>();
        }
    }
    
    [HttpPost]
    public ActionResult<HomelessMessageModel> Post(HomelessMessageModel homelessModel)
    {
        try
        {
           var newHomeless =  _homelessRepository.Add(homelessModel);

           return Ok(newHomeless);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _homelessRepository.Delete(id);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}