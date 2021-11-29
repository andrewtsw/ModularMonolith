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
    [Migration("20210115093318_Migrate-Gsvs-To-UTC")]
    partial class MigrateGsvsToUTC
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

                    b.HasIndex("TaxpayerStoreId", "ProductId")
                        .IsUnique();

                    b.ToTable("Balances");
                });

            modelBuilder.Entity("TCO.SNT.Entities.EsfUserProfile", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupId", "Role");

                    b.ToTable("GroupRoles");
                });

            modelBuilder.Entity("TCO.SNT.Entities.GroupTaxpayerStore", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TaxpayerStoreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupId", "TaxpayerStoreId");

                    b.HasIndex("TaxpayerStoreId");

                    b.ToTable("GroupTaxpayerStores");
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

                    b.Property<DateTimeOffset?>("LastUpdateDateUtc")
                        .HasColumnType("datetimeoffset");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("EndDateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<long>("ExternalId")
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

                    b.Property<DateTimeOffset>("LastUpdateDateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameKz")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameRu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("StartDateUtc")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("Code");

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

                    b.Property<DateTime>("BalanceIncomeUpdatesLastEventDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<long>("BalanceOutcomeUpdatesLastBalanceId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("BalanceOutcomeUpdatesLastEventDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<long>("GsvsLastChangeId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("MeasureUnitsLastEventDateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("SntUpdatesLastEventDateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<long>("SntUpdatesLastSntId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UFormUpdatesLastEventDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<long>("UFormUpdatesLastUFormId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BalanceIncomeUpdatesLastBalanceId = 0L,
                            BalanceIncomeUpdatesLastEventDateUtc = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BalanceOutcomeUpdatesLastBalanceId = 0L,
                            BalanceOutcomeUpdatesLastEventDateUtc = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GsvsLastChangeId = 0L,
                            MeasureUnitsLastEventDateUtc = new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            SntUpdatesLastEventDateUtc = new DateTimeOffset(new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            SntUpdatesLastSntId = 0L,
                            UFormUpdatesLastEventDateUtc = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UFormUpdatesLastUFormId = 0L
                        });
                });

            modelBuilder.Entity("TCO.SNT.Entities.Snt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CancelReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Certificate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatorLogin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatorTin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ExternalId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("InputDateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdateDateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderSignerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Signature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SignatureType")
                        .HasColumnType("int");

                    b.Property<bool>("SignatureValid")
                        .HasColumnType("bit");

                    b.Property<string>("SntBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("Snts");
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

                    b.ToTable("TaxpayerStores");
                });

            modelBuilder.Entity("TCO.SNT.Entities.UForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CancelReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatorLogin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DetailingType")
                        .HasColumnType("int");

                    b.Property<long?>("ExternalId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("InputDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecipientId")
                        .HasColumnType("int");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReorganizationType")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Signature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SignatureType")
                        .HasColumnType("int");

                    b.Property<bool?>("SignatureValid")
                        .HasColumnType("bit");

                    b.Property<decimal?>("SourceTotalSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UFormBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WriteOffReason")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("UForms");
                });

            modelBuilder.Entity("TCO.SNT.Entities.UFormParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgentDocDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgentDocNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ExternalStoreId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaxpayerStoreId")
                        .HasColumnType("int");

                    b.Property<string>("Tin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TaxpayerStoreId");

                    b.ToTable("UFormParticipants");
                });

            modelBuilder.Entity("TCO.SNT.Entities.UFormProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BalanceId")
                        .HasColumnType("int");

                    b.Property<bool?>("CanExport")
                        .HasColumnType("bit");

                    b.Property<int?>("DutyTypeCode")
                        .HasColumnType("int");

                    b.Property<string>("ExternalGsvsCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExternalMeasureUnitCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ExternalProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("ManufactureOrImportCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManufactureOrImportDocNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarkingCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeasureUnitId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginCertificateDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhysicalLabel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PinCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductFormId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductNameInImportDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductNumberInImportDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SourceProductFormId")
                        .HasColumnType("int");

                    b.Property<decimal?>("SpiritPercent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TnvedCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BalanceId");

                    b.HasIndex("MeasureUnitId");

                    b.HasIndex("ProductFormId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SourceProductFormId");

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

            modelBuilder.Entity("TCO.SNT.Entities.GroupTaxpayerStore", b =>
                {
                    b.HasOne("TCO.SNT.Entities.TaxpayerStore", "TaxpayerStore")
                        .WithMany()
                        .HasForeignKey("TaxpayerStoreId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TCO.SNT.Entities.UForm", b =>
                {
                    b.HasOne("TCO.SNT.Entities.UFormParticipant", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TCO.SNT.Entities.UFormParticipant", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TCO.SNT.Entities.UFormParticipant", b =>
                {
                    b.HasOne("TCO.SNT.Entities.TaxpayerStore", "TaxpayerStore")
                        .WithMany()
                        .HasForeignKey("TaxpayerStoreId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TCO.SNT.Entities.UFormProduct", b =>
                {
                    b.HasOne("TCO.SNT.Entities.Balance", "Balance")
                        .WithMany()
                        .HasForeignKey("BalanceId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TCO.SNT.Entities.MeasureUnit", "MeasureUnit")
                        .WithMany()
                        .HasForeignKey("MeasureUnitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCO.SNT.Entities.UForm", "ProductForm")
                        .WithMany("Products")
                        .HasForeignKey("ProductFormId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TCO.SNT.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TCO.SNT.Entities.UForm", "SourceProductForm")
                        .WithMany("SourceProducts")
                        .HasForeignKey("SourceProductFormId")
                        .OnDelete(DeleteBehavior.NoAction);
                });
#pragma warning restore 612, 618
        }
    }
}
