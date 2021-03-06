// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCO.EInvoicing.DataAccess.SqlServer;

namespace TCO.EInvoicing.DataAccess.SqlServer.Migrations
{
    [DbContext(typeof(EInvoicingSqlServerDbContext))]
    [Migration("20211105084701_InvoicesModule_Recreated_Invoices_Model")]
    partial class InvoicesModule_Recreated_Invoices_Model
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ei")
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TCO.EInvoicing.Entities.Awp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AwpDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("AwpSignDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ExternalId")
                        .HasColumnType("bigint");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientTin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderTin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Awps");
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.EInvoicingSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AwpUpdatesLastAwpId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("AwpUpdatesLastEventDateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("InvoicesUpdatesInboundLastEventDateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<long>("InvoicesUpdatesInboundLastInvoiceId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("InvoicesUpdatesOutboundLastEventDateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<long>("InvoicesUpdatesOutboundLastInvoiceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AwpUpdatesLastAwpId = 0L,
                            AwpUpdatesLastEventDateUtc = new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            InvoicesUpdatesInboundLastEventDateUtc = new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            InvoicesUpdatesInboundLastInvoiceId = 0L,
                            InvoicesUpdatesOutboundLastEventDateUtc = new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            InvoicesUpdatesOutboundLastInvoiceId = 0L
                        });
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddInf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerAgentAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerAgentDocDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerAgentDocNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerAgentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerAgentTin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DatePaper")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeliveryDocDate")
                        .HasColumnType("date");

                    b.Property<string>("DeliveryDocNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Direction")
                        .HasColumnType("int");

                    b.Property<long?>("ExternalId")
                        .HasColumnType("bigint");

                    b.Property<int>("InvoiceType")
                        .HasColumnType("int");

                    b.Property<string>("Num")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperatorFullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReasonPaper")
                        .HasColumnType("int");

                    b.Property<string>("SellerAgentAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SellerAgentDocDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SellerAgentDocNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SellerAgentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SellerAgentTin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TurnoverDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique()
                        .HasFilter("[ExternalId] IS NOT NULL");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoiceConsignee", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InvoiceId");

                    b.ToTable("InvoiceConsignees");
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoiceConsignor", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InvoiceId");

                    b.ToTable("InvoiceConsignors");
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoiceCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchTin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReorganizedTin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ShareParticipation")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Statuses")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Tin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceCustomers");
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoiceDeliveryTerm", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ContractDate")
                        .HasColumnType("date");

                    b.Property<string>("ContractNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryConditionCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasContract")
                        .HasColumnType("bit");

                    b.Property<string>("Term")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransportTypeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Warrant")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WarrantDate")
                        .HasColumnType("date");

                    b.HasKey("InvoiceId");

                    b.ToTable("InvoiceDeliveryTerms");
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoiceInfo", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("CancelReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Certificate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("InputDateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("InvoiceBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InvoiceStatus")
                        .HasColumnType("int");

                    b.Property<string>("Kogd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastUpdateDateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Signature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SignatureType")
                        .HasColumnType("int");

                    b.Property<bool>("SignatureValid")
                        .HasColumnType("bit");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InvoiceId");

                    b.HasIndex("InvoiceStatus");

                    b.HasIndex("RegistrationNumber")
                        .IsUnique()
                        .HasFilter("[RegistrationNumber] IS NOT NULL");

                    b.ToTable("InvoiceInfo");
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoiceProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Additional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdditionalUnitNomenclature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CatalogTruId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ExciseAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ExciseRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("KpvedCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("NdsAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("NdsRate")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceWithTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceWithoutTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductDeclaration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductNumberInDeclaration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductNumberInSnt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TnvedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TruOriginCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TurnoverAdjustment")
                        .HasColumnType("int");

                    b.Property<string>("TurnoverCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TurnoverSize")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UnitCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitNomenclature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceProducts");
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoiceProductSet", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("CurrencyRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("NdsRateType")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalExciseAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalNdsAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPriceWithTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPriceWithoutTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalTurnoverSize")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceId");

                    b.ToTable("InvoiceProductSets");
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoicePublicOffice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("Bik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Iik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayPurpose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InvoiceId");

                    b.ToTable("InvoicePublicOffices");
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoiceSeller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchTin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertificateNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertificateSeries")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Iik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsBranchNonResident")
                        .HasColumnType("bit");

                    b.Property<string>("Kbe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NdscaBank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NdscaBik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NdscaIik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NdscaKbe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReorganizedTin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ShareParticipation")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Statuses")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Tin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceSellers");
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.RelatedInvoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Num")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InvoiceId");

                    b.ToTable("RelatedInvoices");
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoiceConsignee", b =>
                {
                    b.HasOne("TCO.EInvoicing.Entities.Invoice", "Invoice")
                        .WithOne("Consignee")
                        .HasForeignKey("TCO.EInvoicing.Entities.InvoiceConsignee", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoiceConsignor", b =>
                {
                    b.HasOne("TCO.EInvoicing.Entities.Invoice", "Invoice")
                        .WithOne("Consignor")
                        .HasForeignKey("TCO.EInvoicing.Entities.InvoiceConsignor", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoiceCustomer", b =>
                {
                    b.HasOne("TCO.EInvoicing.Entities.Invoice", "Invoice")
                        .WithMany("Customers")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoiceDeliveryTerm", b =>
                {
                    b.HasOne("TCO.EInvoicing.Entities.Invoice", "Invoice")
                        .WithOne("DeliveryTerm")
                        .HasForeignKey("TCO.EInvoicing.Entities.InvoiceDeliveryTerm", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoiceInfo", b =>
                {
                    b.HasOne("TCO.EInvoicing.Entities.Invoice", "Invoice")
                        .WithOne("InvoiceInfo")
                        .HasForeignKey("TCO.EInvoicing.Entities.InvoiceInfo", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoiceProduct", b =>
                {
                    b.HasOne("TCO.EInvoicing.Entities.Invoice", "Invoice")
                        .WithMany("Products")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoiceProductSet", b =>
                {
                    b.HasOne("TCO.EInvoicing.Entities.Invoice", "Invoice")
                        .WithOne("ProductSet")
                        .HasForeignKey("TCO.EInvoicing.Entities.InvoiceProductSet", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoicePublicOffice", b =>
                {
                    b.HasOne("TCO.EInvoicing.Entities.Invoice", "Invoice")
                        .WithOne("PublicOffice")
                        .HasForeignKey("TCO.EInvoicing.Entities.InvoicePublicOffice", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.InvoiceSeller", b =>
                {
                    b.HasOne("TCO.EInvoicing.Entities.Invoice", "Invoice")
                        .WithMany("Sellers")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCO.EInvoicing.Entities.RelatedInvoice", b =>
                {
                    b.HasOne("TCO.EInvoicing.Entities.Invoice", "Invoice")
                        .WithOne("RelatedInvoice")
                        .HasForeignKey("TCO.EInvoicing.Entities.RelatedInvoice", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
