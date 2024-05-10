namespace Homeless.Database.Models;

public class HomelessMessageModel
{
    public Guid? Id { get; set; }

    public DateTime? DateTime { get; set; }
    public double? HomelessLocationX { get; set; }
    public double? HomelessLocationY { get; set; }

    public string? Adress { get; set; }


    public Guid? HomelessStatusId { get; set; }
    public Guid? MessageStatusId { get; set; }

    public string? HomelessSurname { get; set; }
    public string? HomelessName { get; set; }
    public string? HomelessPatronymic { get; set; }
    public DateTime? HomelessBirthDate { get; set; }
    public string? HomelessDescription { get; set; }

    public Guid? DocumentType { get; set; }
    public string? DocumentNumber { get; set; }
    public string? OtherDocument { get; set; }

    public string? OtherNeed { get; set; }
    public Guid? NeedTypeId { get; set; }
}