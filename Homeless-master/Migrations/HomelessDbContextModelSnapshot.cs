﻿// <auto-generated />
using System;
using Homeless.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Homeless.Migrations
{
    [DbContext(typeof(HomelessDbContext))]
    partial class HomelessDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            //done
            modelBuilder.Entity("Homeless.Database.Models.DocumentTypeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("DocumentType")
                        .HasColumnType("text");


                    b.HasKey("Id");

                    b.ToTable("DocumentTypes");
                });

            //done
            modelBuilder.Entity("Homeless.Aothorization.Entities.User", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                b.Property<string>("Login")
                    .HasColumnType("text");

                b.Property<string>("Password")
                    .HasColumnType("text");


                b.HasKey("Id");

                b.ToTable("User");
            });


            modelBuilder.Entity("Homeless.Database.Models.HomelessModel", b =>
                {
                    b.Property<Guid?>("Id")
        .ValueGeneratedOnAdd()
        .HasColumnType("uuid");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid?>("DocumentTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("DocumentNumber")
                        .HasColumnType("text");

                    b.Property<string>("OtherDocument")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Homeless");

                    // Внешний ключ
                    b.HasOne("DocumentTypeModel", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            //done

            modelBuilder.Entity("Homeless.Database.Models.HelpPointModel", b =>
            {
                b.Property<Guid?>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<double?>("PointLocationX")
                    .HasColumnType("double precision");

                b.Property<double?>("PointLocationY")
                    .HasColumnType("double precision");

                b.Property<string>("WorkingHours")
                    .HasColumnType("text");

                b.Property<string>("PointName")
                    .HasColumnType("text");

                b.Property<string>("Adress")
                    .HasColumnType("text");


                b.Property<string>("PointDescription")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("HelpPoints");
            });

            modelBuilder.Entity("Homeless.Database.Models.HomelessMessageModel", b =>
            {
                b.Property<Guid?>("Id")
           .ValueGeneratedOnAdd()
           .HasColumnType("uuid");

                b.Property<DateTime?>("DateTime")
                    .HasColumnType("timestamp without time zone");

                b.Property<double?>("HomelessLocationX")
                    .HasColumnType("double precision");

                b.Property<double?>("HomelessLocationY")
                    .HasColumnType("double precision");

                b.Property<string>("Adress")
                   .HasColumnType("text");

                b.Property<Guid?>("HomelessStatusId")
                    .HasColumnType("uuid");

                b.Property<Guid?>("MessageStatusId")
                    .HasColumnType("uuid");

                b.Property<string>("HomelessSurname")
                    .HasColumnType("text");

                b.Property<string>("HomelessName")
                    .HasColumnType("text");

                b.Property<string>("HomelessPatronymic")
                    .HasColumnType("text");

                b.Property<DateTime?>("HomelessBirthDate")
                    .HasColumnType("timestamp without time zone");

                b.Property<string>("HomelessDescription")
                    .HasColumnType("text");

                b.Property<Guid?>("DocumentTypeId")
                    .HasColumnType("uuid");

                b.Property<string>("DocumentNumber")
                    .HasColumnType("text");

                b.Property<string>("OtherDocument")
                    .HasColumnType("text");

                b.Property<string>("OtherNeed")
                    .HasColumnType("text");

                b.Property<Guid?>("NeedTypeId")
                    .HasColumnType("uuid");

                b.HasKey("Id");

                b.ToTable("HomelessMessages");

                // Внешние ключи
                b.HasOne("HomelessStatusModel", "HomelessStatus")
                    .WithMany()
                    .HasForeignKey("HomelessStatusId")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne("DocumentTypeModel", "DocumentType")
                    .WithMany()
                    .HasForeignKey("DocumentTypeId")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne("NeedTypeModel", "NeedType")
                    .WithMany()
                    .HasForeignKey("NeedTypeId")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne("MessageProcessingStatusModel", "MessageStatus")
                    .WithMany()
                    .HasForeignKey("MessageStatusId")
                    .OnDelete(DeleteBehavior.Restrict);
            });


            //done
            modelBuilder.Entity("Homeless.Database.Models.HomelessStateModel", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<string>("State")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("HomelessStatuses");
            });

            //done
            modelBuilder.Entity("Homeless.Database.Models.MessageProcessingStatusModel", b =>
            {
                b.Property<Guid?>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<string>("ProcessingStatus")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("MessageProcessingStatus");
            });

            //done
            modelBuilder.Entity("Homeless.Database.Models.NeedTypeModel", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<string>("NeedType")
                    .HasColumnType("text");

              
                b.HasKey("Id");

                b.ToTable("NeedTypes");
            });

            //done
            modelBuilder.Entity("Homeless.Database.Models.ReferenceInfoModel", b =>
            {
                b.Property<Guid?>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<string>("CharityCenterInfo")
                    .HasColumnType("text");

                b.Property<string>("ActionsInfo")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("ReferenceInfo");
            });

#pragma warning restore 612, 618
        }
    }
}
