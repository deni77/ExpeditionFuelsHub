﻿// <auto-generated />
using System;
using ExpeditionFuelsHub.Infrastrucure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpeditionFuelsHub.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExpeditionFuelsHub.Infrastructure.Data.Entities.ApplicationUser", b =>
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

                    b.Property<bool>("IsActive")
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
                            Id = "87612856-d498-4529-b453-bgrfd8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0a97a6e0-b6db-44cc-b46c-b8d689bf579a",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            IsActive = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@MAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAENJHIT+LsY5kNb4Gwn46U8pC8V9RaUuqflnnnVp9mA+yLtnC+ZToNE0GSwD9ILlhPQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e5fb0b95-a6ce-459f-a0ae-e7f3b9317c85",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8f737030-17fa-463b-a684-b6cd5764a665",
                            Email = "fdispenser@mail.com",
                            EmailConfirmed = false,
                            IsActive = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "FDISPENSER@MAIL.COM",
                            NormalizedUserName = "FDISPENSER",
                            PasswordHash = "AQAAAAEAACcQAAAAEJZv5bZP357yYbxd4qwD59CkxH3e+N6vLcSjedqkarCHxth7apI4rW+BZoFK00CL6A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f06e5ce2-4793-47a9-8aea-a046dcd2d769",
                            TwoFactorEnabled = false,
                            UserName = "fdispenser"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e5616568-f3ee-4969-9e4f-272a67903b57",
                            Email = "guest@mail.com",
                            EmailConfirmed = false,
                            IsActive = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "GUEST@MAIL.COM",
                            NormalizedUserName = "GUEST",
                            PasswordHash = "AQAAAAEAACcQAAAAEKlEM0pxPRmLbBExanBgLsPEIza/1QeTDTE+PrYbhIkEIMxSdr3nJfdnOigcuAFwCg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "19e48b49-113b-4d05-86f8-70ea3c1b4694",
                            TwoFactorEnabled = false,
                            UserName = "guest"
                        });
                });

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

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

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
                            CreatedOn = new DateTime(2022, 12, 15, 9, 23, 27, 776, DateTimeKind.Local).AddTicks(5687),
                            DistributionChannelId = 1,
                            FuelDispenserId = 1,
                            GrossStandardVolume = 9768.876m,
                            ImageUrl = "https://i.trade-cloud.com.cn/upload/6653/image/20211230/2_182318.jpg",
                            IsActive = true,
                            Mass = 3423.879m,
                            ProductId = 1,
                            PurposeId = 1,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2022, 12, 15, 9, 23, 27, 776, DateTimeKind.Local).AddTicks(5741),
                            DistributionChannelId = 2,
                            FuelDispenserId = 1,
                            GrossStandardVolume = 9345768.876m,
                            ImageUrl = "https://autoline.bg/img/s/vlekach-MAN-TGS-18-400---1598979707951979529_big--20090119595756984600.jpg",
                            IsActive = true,
                            Mass = 34453423.879m,
                            ProductId = 2,
                            PurposeId = 2,
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedOn = new DateTime(2022, 12, 15, 9, 23, 27, 776, DateTimeKind.Local).AddTicks(5745),
                            DistributionChannelId = 3,
                            FuelDispenserId = 1,
                            GrossStandardVolume = 93768.876m,
                            ImageUrl = "https://bg.csc-trucks.com/uploads/202221798/foton-10-000-liters-oil-tank-truck23496909900.jpg",
                            IsActive = true,
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

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

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
                            IsActive = true,
                            RegistrationNumber = "AV9876BH",
                            VehicleRegistrationDocumentNumber = "ACF4566AS"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            RegistrationNumber = "BB9876АА",
                            VehicleRegistrationDocumentNumber = "GFR768987"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
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

                    b.HasData(
                        new
                        {
                            Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            ConcurrencyStamp = "1f360438-3aa0-4974-918d-ce5427d82860",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2787b74e-3c0v-466f-m8af-654d56fd9010",
                            ConcurrencyStamp = "f329c9df-eec4-4289-9aa9-7538e49e8939",
                            Name = "User",
                            NormalizedName = "User"
                        },
                        new
                        {
                            Id = "115e174e-5g0e-i46f-86af-458mkifd7210",
                            ConcurrencyStamp = "1994dfb7-8673-4372-8bd3-657a94f96325",
                            Name = "Fdispenser",
                            NormalizedName = "FDISPENSER"
                        });
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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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

                    b.HasData(
                        new
                        {
                            UserId = "87612856-d498-4529-b453-bgrfd8395082",
                            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210"
                        },
                        new
                        {
                            UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            RoleId = "2787b74e-3c0v-466f-m8af-654d56fd9010"
                        },
                        new
                        {
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082",
                            RoleId = "115e174e-5g0e-i46f-86af-458mkifd7210"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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
                    b.HasOne("ExpeditionFuelsHub.Infrastructure.Data.Entities.ApplicationUser", "User")
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
                    b.HasOne("ExpeditionFuelsHub.Infrastructure.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ExpeditionFuelsHub.Infrastructure.Data.Entities.ApplicationUser", null)
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

                    b.HasOne("ExpeditionFuelsHub.Infrastructure.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ExpeditionFuelsHub.Infrastructure.Data.Entities.ApplicationUser", null)
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
