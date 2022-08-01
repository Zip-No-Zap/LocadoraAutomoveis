﻿// <auto-generated />
using System;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    [DbContext(typeof(LocadoraAutomoveisDbContext))]
    partial class LocadoraAutomoveisDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteLocacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CondutorLocacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataDevolvidoDeFato")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("date");

                    b.Property<Guid?>("GrupoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItensTaxaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NivelTanqueVeiculo")
                        .HasColumnType("varchar(10)");

                    b.Property<Guid>("PlanoLocacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PlanoLocacao_Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<decimal>("TotalPrevisto")
                        .HasColumnType("money");

                    b.Property<Guid>("VeiculoLocacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClienteLocacaoId");

                    b.HasIndex("CondutorLocacaoId");

                    b.HasIndex("GrupoId");

                    b.HasIndex("PlanoLocacaoId");

                    b.HasIndex("VeiculoLocacaoId");

                    b.ToTable("TBLOCACAO");
                });

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TBCLIENTE");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.Modulo_Condutor.Condutor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cnh")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Cpf")
                        .IsRequired()
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

                    b.Property<DateTime>("VencimentoCnh")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("TBCONDUTOR");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.Modulo_Funcionario.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("date");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Perfil")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("money");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TBFUNCIONARIO");
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

            modelBuilder.Entity("LocadoraVeiculos.Dominio.Modulo_Plano.Plano", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GrupoVeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LimiteQuilometragem_Controlado")
                        .HasColumnType("float");

                    b.Property<decimal>("ValorDiario_Controlado")
                        .HasColumnType("money");

                    b.Property<decimal>("ValorDiario_Diario")
                        .HasColumnType("money");

                    b.Property<decimal>("ValorDiario_Livre")
                        .HasColumnType("money");

                    b.Property<decimal>("ValorPorKm_Controlado")
                        .HasColumnType("money");

                    b.Property<decimal>("ValorPorKm_Diario")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("GrupoVeiculoId");

                    b.ToTable("TBPLANO");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.Modulo_Taxa.Taxa", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("LocacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("LocacaoId");

                    b.ToTable("TBTAXA");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.Modulo_Veiculo.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<double>("CapacidadeTanque")
                        .HasColumnType("float");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<byte[]>("Foto")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid?>("GrupoPertencenteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<int>("QuilometragemAtual")
                        .HasColumnType("int");

                    b.Property<string>("StatusVeiculo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TipoCombustivel")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoPertencenteId");

                    b.ToTable("TBVEICULO");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.Modulo_Cliente.Cliente", "ClienteLocacao")
                        .WithMany()
                        .HasForeignKey("ClienteLocacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.Dominio.Modulo_Condutor.Condutor", "CondutorLocacao")
                        .WithMany()
                        .HasForeignKey("CondutorLocacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo.GrupoVeiculo", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId");

                    b.HasOne("LocadoraVeiculos.Dominio.Modulo_Plano.Plano", "PlanoLocacao")
                        .WithMany()
                        .HasForeignKey("PlanoLocacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.Dominio.Modulo_Veiculo.Veiculo", "VeiculoLocacao")
                        .WithMany()
                        .HasForeignKey("VeiculoLocacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClienteLocacao");

                    b.Navigation("CondutorLocacao");

                    b.Navigation("Grupo");

                    b.Navigation("PlanoLocacao");

                    b.Navigation("VeiculoLocacao");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.Modulo_Condutor.Condutor", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.Modulo_Cliente.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.Modulo_Plano.Plano", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo.GrupoVeiculo", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoVeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.Modulo_Taxa.Taxa", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.ModuloLocacao.Locacao", null)
                        .WithMany("ItensTaxa")
                        .HasForeignKey("LocacaoId");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.Modulo_Veiculo.Veiculo", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo.GrupoVeiculo", "GrupoPertencente")
                        .WithMany()
                        .HasForeignKey("GrupoPertencenteId");

                    b.Navigation("GrupoPertencente");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.Navigation("ItensTaxa");
                });
#pragma warning restore 612, 618
        }
    }
}
