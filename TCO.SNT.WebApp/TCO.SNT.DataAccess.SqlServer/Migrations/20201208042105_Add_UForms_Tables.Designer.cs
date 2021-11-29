﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCO.SNT.DataAccess.SqlServer;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    [DbContext(typeof(SqlServerDbContext))]
    [Migration("20201208042105_Add_UForms_Tables")]
    partial class Add_UForms_Tables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TCO.SNT.Entities.Balance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanExport")
                        .HasColumnType("bit");

                    b.Property<string>("ExternalMeasureUnitCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ExternalTaxpayerStoreId")
                        .HasColumnType("bigint");

                    b.Property<string>("GtinCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KpvedCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManufactureOrImportDocNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeasureUnitId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhysicalLabel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PinCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductNameInImportDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductNumberInImportDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ProjectCode")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ReserveQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SpiritPercent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TaxpayerStoreId")
                        .HasColumnType("int");

                    b.Property<string>("Tin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TnvedCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MeasureUnitId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.HasIndex("TaxpayerStoreId");

                    b.ToTable("Balances");
                });

            modelBuilder.Entity("TCO.SNT.Entities.EsfUserProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Base64AuthCertificateSecretName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Base64SignCertificateSecretName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordSecretName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SignRSAKeyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsernameSecretName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("EsfUserProfiles");
                });

            modelBuilder.Entity("TCO.SNT.Entities.FavoriteProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("FavoriteProducts");
                });

            modelBuilder.Entity("TCO.SNT.Entities.GroupRole", b =>
                {
                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.HasKey("GroupId", "Role");

                    b.ToTable("GroupRoles");
                });

            modelBuilder.Entity("TCO.SNT.Entities.MeasureUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<string>("CodeMkei")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<string>("CodeOkei")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<string>("CodeTis")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameKz")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("NameRu")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("MeasureUnits");
                });

            modelBuilder.Entity("TCO.SNT.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ExternalId")
                        .HasColumnType("bigint");

                    b.Property<long>("FixedId")
                        .HasColumnType("bigint");

                    b.Property<long>("FixedParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("GsvsCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GsvsTypeCode")
                        .HasColumnType("int");

                    b.Property<bool?>("IsCanSelect")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsExcisable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTwofoldPurpose")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUnique")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsUseInVstore")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsWithdrawal")
                        .HasColumnType("bit");

                    b.Property<int?>("KpvedTypeCode")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameKz")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameRu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FixedId")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TCO.SNT.Entities.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BalanceIncomeUpdatesLastBalanceId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("BalanceIncomeUpdatesLastEventDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("BalanceOutcomeUpdatesLastBalanceId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("BalanceOutcomeUpdatesLastEventDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("GsvsLastChangeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BalanceIncomeUpdatesLastBalanceId = 0L,
                            BalanceIncomeUpdatesLastEventDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BalanceOutcomeUpdatesLastBalanceId = 0L,
                            BalanceOutcomeUpdatesLastEventDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GsvsLastChangeId = 0L
                        });
                });

            modelBuilder.Entity("TCO.SNT.Entities.TaxpayerStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("AlcoholLicenseId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ExternalDocumentId")
                        .HasColumnType("bigint");

                    b.Property<long>("ExternalId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ExternalParentId")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsCooperativeStore")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInherited")
                        .HasColumnType("bit");

                    b.Property<bool>("IsJointStore")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPostingGoods")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPublicStore")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsRawMaterials")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LesseeContractDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LesseeContractNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LesseeTin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OilOvdId")
                        .HasColumnType("bigint");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("PermittedTinList")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponsiblePersonIin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoreTypeCode")
                        .HasColumnType("int");

                    b.Property<string>("Tin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TobaccoOvdId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("ParentId");

                    b.ToTable("TaxpayerStores");
                });

            modelBuilder.Entity("TCO.SNT.Entities.UForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ExternalId")
                        .HasColumnType("bigint");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaxpayerStoreId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaxpayerStoreId");

                    b.ToTable("UForms");
                });

            modelBuilder.Entity("TCO.SNT.Entities.UFormProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MeasureUnitId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UFormId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MeasureUnitId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UFormId");

                    b.ToTable("UFormProducts");
                });

            modelBuilder.Entity("TCO.SNT.Entities.Balance", b =>
                {
                    b.HasOne("TCO.SNT.Entities.MeasureUnit", "MeasureUnit")
                        .WithMany()
                        .HasForeignKey("MeasureUnitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCO.SNT.Entities.TaxpayerStore", "TaxpayerStore")
                        .WithMany()
                        .HasForeignKey("TaxpayerStoreId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TCO.SNT.Entities.FavoriteProduct", b =>
                {
                    b.HasOne("TCO.SNT.Entities.Product", "Product")
                        .WithOne()
                        .HasForeignKey("TCO.SNT.Entities.FavoriteProduct", "ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TCO.SNT.Entities.TaxpayerStore", b =>
                {
                    b.HasOne("TCO.SNT.Entities.TaxpayerStore", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("TCO.SNT.Entities.UForm", b =>
                {
                    b.HasOne("TCO.SNT.Entities.TaxpayerStore", "TaxpayerStore")
                        .WithMany()
                        .HasForeignKey("TaxpayerStoreId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TCO.SNT.Entities.UFormProduct", b =>
                {
                    b.HasOne("TCO.SNT.Entities.MeasureUnit", "MeasureUnit")
                        .WithMany()
                        .HasForeignKey("MeasureUnitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCO.SNT.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCO.SNT.Entities.UForm", null)
                        .WithMany("Products")
                        .HasForeignKey("UFormId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
