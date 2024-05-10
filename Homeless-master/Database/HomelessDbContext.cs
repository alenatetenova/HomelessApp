using Homeless.Authorization.Entities;
using Homeless.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Homeless.Database;

public class HomelessDbContext : DbContext
{
    public HomelessDbContext(DbContextOptions<HomelessDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }


    public DbSet<User> User { get; set; }
    public DbSet<DocumentTypeModel> DocumentType { get; set; }
    public DbSet<HelpPointModel> HelpPoint { get; set; }
    public DbSet<HomelessMessageModel> HomelessMessage { get; set; }
    public DbSet<HomelessModel> Homeless { get; set; }
    public DbSet<HomelessStateModel> HomelessState { get; set; }
    public DbSet<MessageProcessingStatusModel> MessageProcessingStatus { get; set; }
    public DbSet<NeedTypeModel> NeedType { get; set; }
    public DbSet<ReferenceInfoModel> ReferenceInfo { get; set; }

}