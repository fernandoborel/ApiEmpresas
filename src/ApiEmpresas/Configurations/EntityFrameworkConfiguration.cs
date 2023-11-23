using ApiEmpresas.Infra.Data.Contexts;
using ApiEmpresas.Infra.Data.Interfaces;
using ApiEmpresas.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpresas.Services.Configurations
{
    /// <summary>
    /// Classe para configuração do EntityFramework
    /// </summary>
    public class EntityFrameworkConfiguration
    {
        /// <summary>
        /// Configurar o EntityFramework
        /// </summary>
        /// <param name="builder"></param>
        public static void AddEntityFramework(WebApplicationBuilder builder)
        {
            //connection string
            var connectionString = builder.Configuration.GetConnectionString("BDApiEmpresas");

            //injetar a connection string na classe SqlServerContext
            builder.Services.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer(connectionString));

            //injeção de dependência para o UnitOfWork
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
