﻿// <auto-generated />
using System;
using JoinForcesHubAPI.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JoinForcesHubAPI.Infrastructure.Migrations
{
    [DbContext(typeof(JoinForcesHubDbContext))]
    partial class JoinForcesHubDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JoinForcesHub.Domain.Entities.Roles.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UpdatedByUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("JoinForcesHub.Domain.Entities.Roles.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedByUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("JoinForcesHub.Domain.Entities.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CoverPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedByUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EducationStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("GithubLink")
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPremium")
                        .HasColumnType("bit");

                    b.Property<bool>("IsProfileVisible")
                        .HasColumnType("bit");

                    b.Property<string>("JobStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LinkedlnLink")
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("NumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenEndData")
                        .HasColumnType("datetime2");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StackOverFlowLink")
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedByUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserJobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("JoinForcesHub.Domain.Entities.Roles.UserRole", b =>
                {
                    b.HasOne("JoinForcesHub.Domain.Entities.Roles.Role", "Roles")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JoinForcesHub.Domain.Entities.User.User", "Users")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("JoinForcesHub.Domain.Entities.Roles.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("JoinForcesHub.Domain.Entities.User.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
