using ApiEmpresas.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiEmpresas.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento ORM da entidade Empresa
    /// </summary>
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        /// <summary>
        /// Método para fazer o mapeamento da entidade
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            //nome da tabela
            builder.ToTable("FUNCIONARIO");

            //chave primária
            builder.HasKey(f => f.IdFuncionario);

            //mapeamento dos campos da tabela
            builder.Property(f => f.IdFuncionario)
                .HasColumnName("IDFUNCIONARIO")
                .IsRequired();

            builder.Property(f => f.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(f => f.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(f => f.Matricula)
                .HasColumnName("MATRICULA")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(f => f.DataAdmissao)
                .HasColumnName("DATAADMISSAO")
                .HasColumnType("DATE")
                .IsRequired();

            builder.Property(f => f.IdEmpresa)
                .HasColumnName("IDEMPRESA")
                .IsRequired();

            #region Mapeamento de relacionamento 1 para muitos

            builder.HasOne(f => f.Empresa)//Funcionário TEM 1 empresa
                .WithMany(e => e.Funcionarios)//Empresa TEM muitos funcionários
                .HasForeignKey(f => f.IdEmpresa);//Chave estrangeira

            #endregion

            #region Mapeamento de campos únicos

            builder.HasIndex(f => f.Cpf)
                .IsUnique();

            builder.HasIndex(f => f.Matricula)
                .IsUnique();

            #endregion
        }
    }
}
