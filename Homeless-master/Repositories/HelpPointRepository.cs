using Homeless.Database;
using Homeless.Database.Models;

namespace Homeless.Repositories;

public class HelpPointRepository : IHelpPointRepository
{
    private readonly HomelessDbContext _dbContext;

    public HelpPointRepository(HomelessDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IList<HelpPointModel> GetAll()
    {
        return _dbContext.HelpPoint.ToList();
    }

    public HelpPointModel Add(HelpPointModel helpPoint)
    {
        helpPoint.Id = Guid.NewGuid();
        var newHelpPoint = _dbContext.HelpPoint.Add(helpPoint);
        _dbContext.SaveChanges();

        return newHelpPoint.Entity;
    }

    public void Delete(Guid id)
    {
        var helpPointModel = _dbContext.HelpPoint.FirstOrDefault(helpPoint => helpPoint.Id == id);
        
        if (helpPointModel == null)
            return;

        _dbContext.Remove(helpPointModel);
        _dbContext.SaveChanges();
    }
}