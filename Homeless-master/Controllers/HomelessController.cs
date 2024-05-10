using Homeless.Database.Models;
using Homeless.Repositories;
using Microsoft.AspNetCore.Mvc;
using Homeless.Authorization.Attributes;


namespace Homeless.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomelessController : ControllerBase
{
    private readonly IHomelessRepository _homelessRepository;

    public HomelessController(IHomelessRepository homelessRepository)
    {
        _homelessRepository = homelessRepository;
    }

    [Authorize]
    [HttpGet]
    public IEnumerable<HomelessModel> Get()
    {
        try
        {
            return _homelessRepository.GetAll();
        }
        catch (Exception e)
        {
            return new List<HomelessModel>();
        }
    }

    [Authorize]
    [HttpPost]
    public ActionResult<HomelessModel> Post(HomelessModel homelessModel)
    {
        try
        {
         //  homelessModel.Id = Guid.NewGuid();
           var newHomeless =  _homelessRepository.Add(homelessModel);

           return Ok(newHomeless);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<HomelessModel> Put(Guid id, HomelessModel homelessModel)
    {
        try
        {
            var existingHomeless = _homelessRepository.GetById(id);

            if (existingHomeless == null)
                return NotFound();

            // Обновление значений существующей сущности
            existingHomeless.Name = homelessModel.Name;
            existingHomeless.Surname = homelessModel.Surname;
            existingHomeless.Patronymic = homelessModel.Patronymic;
            existingHomeless.BirthDate = homelessModel.BirthDate;
            existingHomeless.Description = homelessModel.Description;
            existingHomeless.DocumentType = homelessModel.DocumentType;
            existingHomeless.DocumentNumber = homelessModel.DocumentNumber;
            existingHomeless.OtherDocument = homelessModel.OtherDocument;

            _homelessRepository.Update(existingHomeless);

            return Ok(existingHomeless);
        }
        catch (Exception e)
        {
            // Обработка ошибки
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [Authorize]
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

    [Authorize]
    [HttpGet("documentTypes")]
    public IEnumerable<DocumentTypeModel> GetDocumentTypes()
    {
        try
        {
            var documentTypes = _homelessRepository.GetAllDocumentTypes();
            Console.WriteLine("Document Types Count: " + documentTypes.Count()); // Отладочный вывод
            return documentTypes;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message); // Отладочный вывод
            return new List<DocumentTypeModel>();
        }
    }
}
