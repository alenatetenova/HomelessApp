using Homeless.Database.Models;

namespace Homeless.Repositories;

public interface IInfoRepository
{
    IList<ReferenceInfoModel> GetAll();
    ReferenceInfoModel Add(ReferenceInfoModel volunteer);
    void Delete(Guid id);
}