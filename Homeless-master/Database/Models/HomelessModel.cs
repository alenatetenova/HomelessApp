namespace Homeless.Database.Models;

public class HomelessModel
{
    public Guid? Id { get; set; }

    public string? Surname { get; set; }
    public string? Name { get; set; }
    public string? Patronymic { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Description { get; set; }

    public Guid? DocumentType { get; set; }
    public string? DocumentNumber { get; set; }
    public string? OtherDocument { get; set; }
}