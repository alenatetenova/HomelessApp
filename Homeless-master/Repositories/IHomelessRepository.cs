using Homeless.Database.Models;

namespace Homeless.Repositories;

public interface IHomelessRepository
{
    IList<HomelessModel> GetAll();

    IList<DocumentTypeModel> GetAllDocumentTypes();

    HomelessModel GetById(Guid homelessId);
  
    HomelessModel Add(HomelessModel homeless);

    void Delete(Guid HomelessId);

    void Update(HomelessModel homeless);

}