namespace Homeless.Database.Models;

public class HelpPointModel
{
    public Guid? Id { get; set; }
    public double? PointLocationX { get; set; }
    public double? PointLocationY { get; set; }
    public string? WorkingHours { get; set; }
    public string? PointName { get; set; }
    public string? Adress { get; set; }

    public string? PointDescription { get; set; }
}