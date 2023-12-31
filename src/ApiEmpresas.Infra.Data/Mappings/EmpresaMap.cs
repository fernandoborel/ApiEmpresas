﻿using ApiEmpresas.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiEmpresas.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento ORM da entidade Empresa
    /// </summary>
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        /// <summary>
        /// Método para fazer o mapeamento da entidade
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            //nome da tabela
            builder.ToTable("EMPRESA");

            //chave primária
            builder.HasKey(e => e.IdEmpresa);

            //mapeamento dos campos da tabela
            builder.Property(e => e.IdEmpresa)
                .HasColumnName("IDEMPRESA");
            
            builder.Property(e => e.NomeFantasia)
                .HasColumnName("NOMEFANTASIA")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.RazaoSocial)
                .HasColumnName("RAZAOSOCIAL")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Cnpj)
                .HasColumnName("CNPJ")
                .HasMaxLength(20)
                .IsRequired();

            #region Mapeamento de campos únicos

            builder.HasIndex(e => e.Cnpj)
                .IsUnique();

            #endregion
        }
    }
}
