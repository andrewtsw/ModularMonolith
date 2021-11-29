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
    [Migration("20201102042533_Add_Unique_Index_To_Products_Table")]
    partial class Add_Unique_Index_To_Products_Table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
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

                    b.Property<long>("ExternalBalanceId")
                        .HasColumnType("bigint");

                    b.Property<string>("GtinCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KpvedCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManufactureOrImportDocNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeasureUnitCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhysicalLabel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PinCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ProductId")
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

                    b.Property<long>("TaxpayerStoreId")
                        .HasColumnType("bigint");

                    b.Property<string>("Tin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TnvedCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExternalBalanceId")
                        .IsUnique();

                    b.HasIndex("WarehouseId");

                    b.ToTable("Balances");
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

                    b.Property<long>("GsvsLastChangeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GsvsLastChangeId = 0L
                        });
                });

            modelBuilder.Entity("TCO.SNT.Entities.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("AlcoholLicenseId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DocumentId")
                        .HasColumnType("bigint");

                    b.Property<long>("ExternalId")
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

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

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

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("TCO.SNT.Entities.Balance", b =>
                {
                    b.HasOne("TCO.SNT.Entities.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
