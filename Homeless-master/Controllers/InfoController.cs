using Homeless.Database.Models;
using Homeless.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Homeless.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InfoController : ControllerBase
{
    private readonly IInfoRepository _volunteerRepository;

    public InfoController(IInfoRepository volunteerRepository)
    {
        _volunteerRepository = volunteerRepository;
    }

    [HttpGet]
    public IEnumerable<ReferenceInfoModel> Get()
    {
        try
        {
            return _volunteerRepository.GetAll();
        }
        catch (Exception e)
        {
            return new List<ReferenceInfoModel>();
        }
    }
    
    [HttpPost]
    public ActionResult<ReferenceInfoModel> Post(ReferenceInfoModel volunteerModel)
    {
        try
        {
            var newVolunteer =  _volunteerRepository.Add(volunteerModel);

            return Ok(newVolunteer);
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
            _volunteerRepository.Delete(id);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}