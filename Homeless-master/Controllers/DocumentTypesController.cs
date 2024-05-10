using Homeless.Database.Models;
using Homeless.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Homeless.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentTypesController : ControllerBase
{
    private readonly IDocumentTypeRepository _documentTypeRepository;

    public DocumentTypesController(IDocumentTypeRepository documentTypeRepository)
    {
        _documentTypeRepository = documentTypeRepository;
    }


    
}