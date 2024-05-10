using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homeless.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
             name: "HelpPoints",
             columns: table => new
             {
                 Id = table.Column<Guid>(type: "uuid", nullable: false),
                 PointLocationX = table.Column<double>(type: "double precision", nullable: true),
                 PointLocationY = table.Column<double>(type: "double precision", nullable: true),
                 WorkingHours = table.Column<string>(type: "text", nullable: true),
                 PointName = table.Column<string>(type: "text", nullable: true),
                 Adress = table.Column<string>(type: "text", nullable: true),

                 PointDescription = table.Column<string>(type: "text", nullable: true)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_HelpPoints", x => x.Id);
             });

            migrationBuilder.CreateTable(
                name: "NeedTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NeedType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeedTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeedTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
               name: "MessageProcessingStatus",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uuid", nullable: false),
                   ProcessingStatus = table.Column<string>(type: "text", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_MessageProcessingStatus", x => x.Id);
               });

            migrationBuilder.CreateTable(
               name: "ReferenceInfo",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uuid", nullable: false),
                   CharityCenterInfo = table.Column<string>(type: "text", nullable: true),
                   ActionsInfo = table.Column<string>(type: "text", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_ReferenceInfo", x => x.Id);
               });


            migrationBuilder.CreateTable(
               name: "DocumentTypes",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uuid", nullable: false),
                   DocumentType = table.Column<string>(type: "text", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_DocumentTypes", x => x.Id);
               });
                        

            migrationBuilder.CreateTable(
               name: "Homeless",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uuid", nullable: false),
                   Name = table.Column<string>(type: "text", nullable: true),
                   Surname = table.Column<string>(type: "text", nullable: true),
                   Patronymic = table.Column<string>(type: "text", nullable: true),
                   BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                   Description = table.Column<string>(type: "text", nullable: true),
                   DocumentTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                   DocumentNumber = table.Column<string>(type: "text", nullable: true),
                   OtherDocument = table.Column<string>(type: "text", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Homeless", x => x.Id);
                   table.ForeignKey(
                       name: "FK_Homeless_DocumentTypes_DocumentTypeId",
                       column: x => x.DocumentTypeId,
                       principalTable: "DocumentTypes",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Restrict);
               });

            


        migrationBuilder.CreateTable(
                   name: "HomelessStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    State = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomelessStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
               name: "HomelessMessages",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uuid", nullable: false),
                   Adress = table.Column<string>(type: "text", nullable: true),

                   DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                   HomelessLocationX = table.Column<double>(type: "double precision", nullable: true),
                   HomelessLocationY = table.Column<double>(type: "double precision", nullable: true),
                   HomelessStatusId = table.Column<Guid>(type: "uuid", nullable: true),
                   MessageStatusId = table.Column<Guid>(type: "uuid", nullable: true),
                   HomelessSurname = table.Column<string>(type: "text", nullable: true),
                   HomelessName = table.Column<string>(type: "text", nullable: true),
                   HomelessPatronymic = table.Column<string>(type: "text", nullable: true),
                   HomelessBirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                   HomelessDescription = table.Column<string>(type: "text", nullable: true),
                   DocumentTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                   DocumentNumber = table.Column<string>(type: "text", nullable: true),
                   OtherDocument = table.Column<string>(type: "text", nullable: true),
                   OtherNeed = table.Column<string>(type: "text", nullable: true),
                   NeedTypeId = table.Column<Guid>(type: "uuid", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_HomelessMessages", x => x.Id);
                   table.ForeignKey(
                       name: "FK_HomelessMessages_HomelessStatuses_HomelessStatusId",
                       column: x => x.HomelessStatusId,
                       principalTable: "HomelessStatuses",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Restrict);
                   table.ForeignKey(
                      name: "FK_HomelessMessages_DocumentTypes_DocumentTypeId",
                      column: x => x.DocumentTypeId,
                      principalTable: "DocumentTypes",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
                   table.ForeignKey(
                      name: "FK_HomelessMessages_HomelessStatuses_NeedTypeId",
                      column: x => x.NeedTypeId,
                      principalTable: "NeedTypes",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
                   table.ForeignKey(
                      name: "FK_HomelessMessages_DocumentTypes_MessageStatusId",
                      column: x => x.MessageStatusId,
                      principalTable: "MessageProcessingStatus",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
                   // Add other foreign key constraints here if needed
               });

            migrationBuilder.CreateIndex(
               name: "IX_HomelessMessages_HomelessStatusId",
               table: "HomelessMessages",
               column: "HomelessStatusId");

            migrationBuilder.CreateIndex(
               name: "FK_Homeless_DocumentTypes_DocumentTypeId",
               table: "Homeless",
               column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
               name: "FK_HomelessMessages_DocumentTypes_DocumentTypeId",
               table: "HomelessMessages",
               column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
               name: "FK_HomelessMessages_HomelessStatuses_NeedTypeId",
               table: "HomelessMessages",
               column: "NeedTypeId");

            migrationBuilder.CreateIndex(
               name: "FK_HomelessMessages_DocumentTypes_MessageStatusId",
               table: "HomelessMessages",
               column: "MessageStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HelpPoints"); //-

            migrationBuilder.DropTable(
                name: "Homeless"); //-

            migrationBuilder.DropTable(
                name: "HomelessMessages");

            migrationBuilder.DropTable(
                name: "NeedTypes"); //-

            migrationBuilder.DropTable(
                name: "MessageProcessingStatus"); //-

            migrationBuilder.DropTable(
                name: "ReferenceInfo"); //-

            migrationBuilder.DropTable(
                name: "DocumentTypes"); //-

            migrationBuilder.DropTable(
                name: "HomelessStatuses"); //-
        }
    }
}
