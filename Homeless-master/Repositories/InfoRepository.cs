using Homeless.Database;
using Homeless.Database.Models;

namespace Homeless.Repositories;

public class InfoRepository : IInfoRepository
{
    private readonly HomelessDbContext _dbContext;

    public InfoRepository(HomelessDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IList<ReferenceInfoModel> GetAll()
    {
        return _dbContext.ReferenceInfo.ToList();
    }

    public ReferenceInfoModel Add(ReferenceInfoModel volunteer)
    {
        volunteer.Id = Guid.NewGuid();
        var newVolunteer = _dbContext.ReferenceInfo.Add(volunteer);
        _dbContext.SaveChanges();

        return newVolunteer.Entity;
    }

    public void Delete(Guid id)
    {
        var volunteerModel = _dbContext.ReferenceInfo.FirstOrDefault(volunteer => volunteer.Id == id);
        
        if (volunteerModel == null)
            return;

        _dbContext.Remove(volunteerModel);
        _dbContext.SaveChanges();
    }
}