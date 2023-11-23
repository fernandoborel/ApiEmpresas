using ApiEmpresas.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiEmpresas.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //nome da tabela
            builder.ToTable("USUARIO");

            //chave primária
            builder.HasKey(u => u.IdUsuario);

            //mapeamento dos campos da tabela
            builder.Property(u => u.IdUsuario)
                .HasColumnName("IDUSUARIO");

            builder.Property(u => u.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnName("SENHA")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(u => u.DataInclusao)
                .HasColumnName("DATAINCLUSAO")
                .HasColumnType("datetime")
                .IsRequired();

            #region Mapeamento do campo único

            builder.HasIndex(u => u.Email)
                .IsUnique();

            #endregion
        }
    }
}
