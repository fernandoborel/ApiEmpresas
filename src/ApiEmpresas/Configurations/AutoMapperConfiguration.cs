namespace ApiEmpresas.Services.Configurations
{
    /// <summary>
    /// Classe para configuração do AutoMapper
    /// </summary>
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// Método para configuração do uso do AutoMapper
        /// </summary>
        /// <param name="builder"></param>
        public static void AddAutoMapper(WebApplicationBuilder builder)
        {
            //configurar o AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
