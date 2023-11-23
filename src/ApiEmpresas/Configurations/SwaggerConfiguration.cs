using Microsoft.OpenApi.Models;

namespace ApiEmpresas.Services.Configurations
{
    /// <summary>
    /// Classe para configuração da documentação do Swagger
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Configurar o conteúdo da documentação do Swagger
        /// </summary>
        /// <param name="builder"></param>
        public static void AddSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API controle de empresas / funcionários",
                    Description = "Projeto desenvolvido em NET6 API com EntityFramework SqlServer",
                    Contact = new OpenApiContact
                    {
                         Name = "Fernando Borel",
                         Url = new Uri("https://github.com/fernandoborel"),
                         Email = "fernandomenezesborel@gmail.com"
                    }
                });
            });
        }
    }
}
