using Homeless.Database.Models;

namespace Homeless.Repositories;

public interface IHelpPointRepository
{
    IList<HelpPointModel> GetAll();
    HelpPointModel Add(HelpPointModel helpPoint);
    void Delete(Guid id);
}