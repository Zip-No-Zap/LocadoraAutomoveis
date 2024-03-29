﻿// <auto-generated />
using System;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    [DbContext(typeof(LocadoraAutomoveisDbContext))]
    [Migration("20220727221632_AddClienteTestes")]
    partial class AddClienteTestes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LocadoraVeiculos.Dominio.Modulo_Cliente.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cnpj")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Cpf")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TipoCliente")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("TBCLIENTE");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo.GrupoVeiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("TBGRUPOVEICULO");
                });
#pragma warning restore 612, 618
        }
    }
}
