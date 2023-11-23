﻿// <auto-generated />
using System;
using ApiEmpresas.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiEmpresas.Infra.Data.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    partial class SqlServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiEmpresas.Infra.Data.Entities.Empresa", b =>
                {
                    b.Property<Guid>("IdEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDEMPRESA");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CNPJ");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOMEFANTASIA");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("RAZAOSOCIAL");

                    b.HasKey("IdEmpresa");

                    b.HasIndex("Cnpj")
                        .IsUnique();

                    b.ToTable("EMPRESA", (string)null);
                });

            modelBuilder.Entity("ApiEmpresas.Infra.Data.Entities.Funcionario", b =>
                {
                    b.Property<Guid>("IdFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDFUNCIONARIO");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("CPF");

                    b.Property<DateTime?>("DataAdmissao")
                        .IsRequired()
                        .HasColumnType("DATE")
                        .HasColumnName("DATAADMISSAO");

                    b.Property<Guid>("IdEmpresa")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDEMPRESA");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("MATRICULA");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOME");

                    b.HasKey("IdFuncionario");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("IdEmpresa");

                    b.HasIndex("Matricula")
                        .IsUnique();

                    b.ToTable("FUNCIONARIO", (string)null);
                });

            modelBuilder.Entity("ApiEmpresas.Infra.Data.Entities.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDUSUARIO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime")
                        .HasColumnName("DATAINCLUSAO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOME");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("SENHA");

                    b.HasKey("IdUsuario");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("USUARIO", (string)null);
                });

            modelBuilder.Entity("ApiEmpresas.Infra.Data.Entities.Funcionario", b =>
                {
                    b.HasOne("ApiEmpresas.Infra.Data.Entities.Empresa", "Empresa")
                        .WithMany("Funcionarios")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("ApiEmpresas.Infra.Data.Entities.Empresa", b =>
                {
                    b.Navigation("Funcionarios");
                });
#pragma warning restore 612, 618
        }
    }
}
