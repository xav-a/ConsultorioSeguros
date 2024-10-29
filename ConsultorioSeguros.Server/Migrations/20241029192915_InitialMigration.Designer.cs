﻿// <auto-generated />
using ConsultorioSeguros.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsultorioSeguros.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241029192915_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConsultorioSeguros.Server.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("IdentificationNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Names")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdentificationNumber");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ConsultorioSeguros.Server.Entities.InsurancePlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Premium")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Code");

                    b.ToTable("InsurancePlans");
                });

            modelBuilder.Entity("ConsultorioSeguros.Server.Entities.InsurancePolicy", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("InsurancePlanId")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.HasIndex("ClientId");

                    b.HasIndex("InsurancePlanId");

                    b.ToTable("InsurancePolicies");
                });

            modelBuilder.Entity("ConsultorioSeguros.Server.Entities.InsurancePolicy", b =>
                {
                    b.HasOne("ConsultorioSeguros.Server.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsultorioSeguros.Server.Entities.InsurancePlan", "InsurancePlan")
                        .WithMany()
                        .HasForeignKey("InsurancePlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("InsurancePlan");
                });
#pragma warning restore 612, 618
        }
    }
}