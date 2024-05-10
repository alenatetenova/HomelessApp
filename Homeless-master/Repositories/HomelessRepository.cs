using Homeless.Database;
using Homeless.Database.Models;

namespace Homeless.Repositories;

public class HomelessRepository : IHomelessRepository
{
    private readonly HomelessDbContext _dbContext;

    public HomelessRepository(HomelessDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IList<HomelessModel> GetAll()
    {
        return _dbContext.Homeless.ToList();
    }

    public IList<DocumentTypeModel> GetAllDocumentTypes()
    {
        return _dbContext.DocumentType.ToList();
    }

    public HomelessModel Add(HomelessModel homeless)
    {
        // homeless.Id = Guid.NewGuid();
        try
        {
            var newHomeless = _dbContext.Homeless.Add(homeless);
            _dbContext.SaveChanges();

            return newHomeless.Entity;
        }
        catch(Exception ex) { 
            
            return null;
        }
    }

    public HomelessModel GetById(Guid homelessId)
    {
        return _dbContext.Homeless.FirstOrDefault(h => h.Id == homelessId);
    }

    public void Update(HomelessModel homeless)
    {
        var existingHomeless = _dbContext.Homeless.FirstOrDefault(h => h.Id == homeless.Id);

        if (existingHomeless == null)
            throw new Exception("Homeless not found");

        existingHomeless.Name = homeless.Name;
        existingHomeless.Surname = homeless.Surname;
        existingHomeless.Patronymic = homeless.Patronymic;
        existingHomeless.BirthDate = homeless.BirthDate;
        existingHomeless.Description = homeless.Description;
        existingHomeless.DocumentType = homeless.DocumentType;
        existingHomeless.DocumentNumber = homeless.DocumentNumber;
        existingHomeless.OtherDocument = homeless.OtherDocument;

        _dbContext.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var homelessModel = _dbContext.Homeless.FirstOrDefault(homeless => homeless.Id == id);
        
        if (homelessModel == null)
            return;

        _dbContext.Remove(homelessModel);
        _dbContext.SaveChanges();
    }


}