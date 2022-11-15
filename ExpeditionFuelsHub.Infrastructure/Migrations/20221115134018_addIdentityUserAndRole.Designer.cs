﻿// <auto-generated />
using System;
using ExpeditionFuelsHub.Infrastrucure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpeditionFuelsHub.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221115134018_addIdentityUserAndRole")]
    partial class addIdentityUserAndRole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExpeditionFuelsHub.Infrastructure.Data.Entities.BillLading", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("DistributionChannelId")
                        .HasColumnType("int");

                    b.Property<int>("FuelDispenserId")
                        .HasColumnType("int");

                    b.Property<decimal>("GrossStandardVolume")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Mass")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("PurposeId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DistributionChannelId");

                    b.HasIndex("FuelDispenserId");

                    b.HasIndex("ProductId");

                    b.HasIndex("PurposeId");

                    b.HasIndex("VehicleId");

                    b.ToTable("BillLadings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2022, 11, 15, 15, 40, 18, 291, DateTimeKind.Local).AddTicks(4809),
                            DistributionChannelId = 1,
                            FuelDispenserId = 1,
                            GrossStandardVolume = 9768.876m,
                            ImageUrl = "https://i.trade-cloud.com.cn/upload/6653/image/20211230/2_182318.jpg",
                            Mass = 3423.879m,
                            ProductId = 1,
                            PurposeId = 1,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2022, 11, 15, 15, 40, 18, 291, DateTimeKind.Local).AddTicks(4858),
                            DistributionChannelId = 2,
                            FuelDispenserId = 1,
                            GrossStandardVolume = 9345768.876m,
                            ImageUrl = "https://autoline.bg/img/s/vlekach-MAN-TGS-18-400---1598979707951979529_big--20090119595756984600.jpg",
                            Mass = 34453423.879m,
                            ProductId = 2,
                            PurposeId = 2,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedOn = new DateTime(2022, 11, 15, 15, 40, 18, 291, DateTimeKind.Local).AddTicks(4861),
                            DistributionChannelId = 3,
                            FuelDispenserId = 1,
                            GrossStandardVolume = 93768.876m,
                            ImageUrl = "https://bg.csc-trucks.com/uploads/202221798/foton-10-000-liters-oil-tank-truck23496909900.jpg",
                            Mass = 344423.879m,
                            ProductId = 3,
                            PurposeId = 3,
                            VehicleId = 3
                        });
                });

            modelBuilder.Entity("ExpeditionFuelsHub.Infrastructure.Data.Entities.DistributionChannel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("DistributionChannels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "For Country"
                        },
                        new
                        {
                            Id = 2,
                            Name = "EU"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Export"
                        });
                });

            modelBuilder.Entity("ExpeditionFuelsHub.Infrastructure.Data.Entities.FuelDispenser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FuelDispensers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PhoneNumber = "+359888888888",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        });
                });

            modelBuilder.Entity("ExpeditionFuelsHub.Infrastructure.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("ProductCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Биодизел",
                            ProductCode = 100
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Авт.бензин А-100Н-9%Биоетанол",
                            ProductCode = 200
                        },
                        new
                        {
                            Id = 3,
                            FullName = "А-98 ЕКТО",
                            ProductCode = 300
                        },
                        new
                        {
                            Id = 4,
                            FullName = "А-98 Н1",
                            ProductCode = 400
                        });
                });

            modelBuilder.Entity("ExpeditionFuelsHub.Infrastructure.Data.Entities.Purpose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Purposes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = 11,
                            Name = "Отложен акциз - до данъчен склад в страната"
                        },
                        new
                        {
                            Id = 2,
                            Code = 710,
                            Name = "Съдържащи биоетанол"
                        },
                        new
                        {
                            Id = 3,
                            Code = 700,
                            Name = "Съдържащи биодизел"
                        },
                        new
                        {
                            Id = 4,
                            Code = 400,
                            Name = "Крайни потребители"
                        });
                });

            modelBuilder.Entity("ExpeditionFuelsHub.Infrastructure.Data.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("VehicleRegistrationDocumentNumber")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RegistrationNumber = "AV9876BH",
                            VehicleRegistrationDocumentNumber = "ACF4566AS"
                        },
                        new
                        {
                            Id = 2,
                            RegistrationNumber = "BB9876АА",
                            VehicleRegistrationDocumentNumber = "GFR768987"
                        },
                        new
                        {
                            Id = 3,
                            RegistrationNumber = "AB4576АC",
                            VehicleRegistrationDocumentNumber = "DFR400987"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "03b2d06c-a542-4cd8-98af-5d9708183ec3",
                            Email = "fdispenser@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "fdispenser@mail.com",
                            NormalizedUserName = "fdispenser@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEAi/yTmZ4f/aLB+v69A6JEF4h92i+7W2kKvd+t8VRH09KI+Vs9DvE2G4UyM+c587ZQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2f7ac8c6-7845-4242-a148-7a32425f5aae",
                            TwoFactorEnabled = false,
                            UserName = "fdispenser@mail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "81b67ad9-2870-401b-9899-982355abd88c",
                            Email = "guest@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "guest@mail.com",
                            NormalizedUserName = "guest@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEFPnehOSWCAgUHszuQwlz6fH9SfYwNfvsJY8MwK/IWSSP9DivYL2ctaTxUykdujy9A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b6d8140b-9454-416f-a97c-1cd79fd49095",
                            TwoFactorEnabled = false,
                            UserName = "guest@mail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ExpeditionFuelsHub.Infrastructure.Data.Entities.BillLading", b =>
                {
                    b.HasOne("ExpeditionFuelsHub.Infrastructure.Data.Entities.DistributionChannel", "DistributionChannel")
                        .WithMany("BillLadings")
                        .HasForeignKey("DistributionChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpeditionFuelsHub.Infrastructure.Data.Entities.FuelDispenser", "FuelDispenser")
                        .WithMany()
                        .HasForeignKey("FuelDispenserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpeditionFuelsHub.Infrastructure.Data.Entities.Product", "Product")
                        .WithMany("BillLadings")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpeditionFuelsHub.Infrastructure.Data.Entities.Purpose", "Purpose")
                        .WithMany("BillLadings")
                        .HasForeignKey("PurposeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpeditionFuelsHub.Infrastructure.Data.Entities.Vehicle", "Vehicle")
                        .WithMany("BillLadings")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DistributionChannel");

                    b.Navigation("FuelDispenser");

                    b.Navigation("Product");

                    b.Navigation("Purpose");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("ExpeditionFuelsHub.Infrastructure.Data.Entities.FuelDispenser", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExpeditionFuelsHub.Infrastructure.Data.Entities.DistributionChannel", b =>
                {
                    b.Navigation("BillLadings");
                });

            modelBuilder.Entity("ExpeditionFuelsHub.Infrastructure.Data.Entities.Product", b =>
                {
                    b.Navigation("BillLadings");
                });

            modelBuilder.Entity("ExpeditionFuelsHub.Infrastructure.Data.Entities.Purpose", b =>
                {
                    b.Navigation("BillLadings");
                });

            modelBuilder.Entity("ExpeditionFuelsHub.Infrastructure.Data.Entities.Vehicle", b =>
                {
                    b.Navigation("BillLadings");
                });
#pragma warning restore 612, 618
        }
    }
}
