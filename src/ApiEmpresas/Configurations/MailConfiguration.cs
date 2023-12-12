using ApiEmpresas.Messages.Services;
using ApiEmpresas.Messages.Settings;

namespace ApiEmpresas.Services.Configurations
{
    /// <summary>
    /// classe de configuração para serviço de envio de e-mail
    /// </summary>
    public class MailConfiguration
    {
        /// <summary>
        /// método de configuração do serviço de envio de e-mail
        /// </summary>
        public static void AddMail(WebApplicationBuilder builder)
        {
            #region Capturar as configs do appsettings.json

            var settings = builder.Configuration.GetSection("MailSettings");
            builder.Services.Configure<MailSettings>(settings);

            var mailSettings = settings.Get<MailSettings>();

            #endregion

            #region Injeção de dependência

            builder.Services.AddTransient<MailService>(map => new MailService(mailSettings));

            #endregion
        }
    }
}
