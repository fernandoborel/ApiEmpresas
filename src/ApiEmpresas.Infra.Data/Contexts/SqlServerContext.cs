using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpresas.Infra.Data.Contexts
{
    /// <summary>
    /// Classe para configuração (contexto) do EntityFramework no projeto Infra.Data
    /// </summary>
    public class SqlServerContext : DbContext
    {
        //construtor para injeção de dependência
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {
            
        }
        
        //sobrescrevendo o método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //informar cada classe de mapeamento do projeto Infra.Data
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        //declarar uma prop DbSet para cada entidade do projeto Infra.Data
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
