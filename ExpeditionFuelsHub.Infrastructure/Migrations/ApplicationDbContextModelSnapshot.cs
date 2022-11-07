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

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<decimal>("Mass")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("PurposeId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<string>("WriterUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DistributionChannelId");

                    b.HasIndex("FuelDispenserId");

                    b.HasIndex("ProductId");

                    b.HasIndex("PurposeId");

                    b.HasIndex("VehicleId");

                    b.HasIndex("WriterUserId");

                    b.ToTable("BillLadings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(4039),
                            DistributionChannelId = 1,
                            FuelDispenserId = 1,
                            GrossStandardVolume = 9768.876m,
                            IsValid = true,
                            Mass = 3423.879m,
                            ModifiedOn = new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(4045),
                            ProductId = 2,
                            PurposeId = 2,
                            VehicleId = 2,
                            WriterUserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                        });
                });

            modelBuilder.Entity("ExpeditionFuelsHub.Infrastructure.Data.Entities.DistributionChannel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("DistributionChannels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsValid = true,
                            ModifiedOn = new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3913),
                            Name = "DistributionChannel_1"
                        },
                        new
                        {
                            Id = 2,
                            IsValid = true,
                            ModifiedOn = new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3921),
                            Name = "DistributionChannel_2"
                        },
                        new
                        {
                            Id = 3,
                            IsValid = true,
                            ModifiedOn = new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3924),
                            Name = "DistributionChannel_3"
                        },
                        new
                        {
                            Id = 4,
                            IsValid = true,
                            ModifiedOn = new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3927),
                            Name = "DistributionChannel_4"
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
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "А-95Н",
                            IsValid = true,
                            ModifiedOn = new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3143),
                            ProductCode = "552"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "А-95НВ",
                            IsValid = true,
                            ModifiedOn = new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3188),
                            ProductCode = "101"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "А-98 ЕКТО",
                            IsValid = true,
                            ModifiedOn = new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3191),
                            ProductCode = "102"
                        },
                        new
                        {
                            Id = 4,
                            FullName = "А-98 Н1",
                            IsValid = true,
                            ModifiedOn = new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3194),
                            ProductCode = "105"
                        });
                });

            modelBuilder.Entity("ExpeditionFuelsHub.Infrastructure.Data.Entities.Purpose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte>("Code")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Purposes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = (byte)65,
                            ModifiedOn = new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3674),
                            Name = "ForCountry"
                        },
                        new
                        {
                            Id = 2,
                            Code = (byte)66,
                            ModifiedOn = new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3687),
                            Name = "ForCountry_1"
                        },
                        new
                        {
                            Id = 3,
                            Code = (byte)64,
                            ModifiedOn = new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3690),
                            Name = "ForCountry_3"
                        },
                        new
                        {
                            Id = 4,
                            Code = (byte)67,
                            ModifiedOn = new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3692),
                            Name = "ForCountry_4"
                        });
                });

            modelBuilder.Entity("ExpeditionFuelsHub.Infrastructure.Data.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("VehicleRegistrationDocumentNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsValid = false,
                            ModifiedOn = new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3811),
                            RegistrationNumber = "AV9876BH",
                            VehicleRegistrationDocumentNumber = "ACF4566ASSSS"
                        },
                        new
                        {
                            Id = 2,
                            IsValid = false,
                            ModifiedOn = new DateTime(2022, 11, 7, 16, 15, 54, 990, DateTimeKind.Local).AddTicks(3822),
                            RegistrationNumber = "BB9876aa",
                            VehicleRegistrationDocumentNumber = "ACF4566ASSSSFGR"
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
                            ConcurrencyStamp = "583c7c12-4aab-4345-bf4d-5bc1cc59f442",
                            Email = "fdispenser@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "fdispenser@mail.com",
                            NormalizedUserName = "fdispenser@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEGPowsvd2NA41Kjwl7TE7TZfWIgCNZzDRfeMqC55HYeX7cd7fWHn5O/pUPbkBHn4Xg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7096191a-5c21-4b76-a401-b55a562a7a64",
                            TwoFactorEnabled = false,
                            UserName = "fdispenser@mail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d7a2cd56-c88f-405e-b8bf-44d06e4a43f0",
                            Email = "guest@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "guest@mail.com",
                            NormalizedUserName = "guest@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEBirgBQDHHKNOmHO6F9GGcMif+B6SHz0Q22IvWnagAOgILGwdsIrnAbcilOej+7Tsg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a577501f-fb3f-4e95-bdb2-e8261d9a0c99",
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "WriterUser")
                        .WithMany()
                        .HasForeignKey("WriterUserId");

                    b.Navigation("DistributionChannel");

                    b.Navigation("FuelDispenser");

                    b.Navigation("Product");

                    b.Navigation("Purpose");

                    b.Navigation("Vehicle");

                    b.Navigation("WriterUser");
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
