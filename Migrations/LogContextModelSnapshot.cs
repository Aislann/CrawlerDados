﻿// <auto-generated />
using System;
using CrawlerDados.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrawlerDados.Migrations
{
    [DbContext(typeof(LogContext))]
    partial class LogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CrawlerDados.Models.Log", b =>
                {
                    b.Property<int>("iDlOG")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("iDlOG"), 1L, 1);

                    b.Property<string>("CodigoRobo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateLog")
                        .HasColumnType("datetime2");

                    b.Property<string>("Etapa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdProdutoAPI")
                        .HasColumnType("int");

                    b.Property<string>("InformacaoLog")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioRobo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("iDlOG");

                    b.ToTable("LOGROBO");
                });
#pragma warning restore 612, 618
        }
    }
}