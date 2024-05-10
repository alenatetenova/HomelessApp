using Homeless.Database.Models;

namespace Homeless.Repositories;

public interface IDocumentTypeRepository
{
    IList<DocumentTypeModel> GetAllDocumentTypes();
  
}