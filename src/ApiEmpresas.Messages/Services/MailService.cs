using ApiEmpresas.Messages.Settings;
using System.Net;
using System.Net.Mail;

namespace ApiEmpresas.Messages.Services
{
    /// <summary>
    /// classe para serviço de envio de e-mail
    /// </summary>
    public class MailService
    {
        //atributo
        private readonly MailSettings _mailSettings;

        //construtor
        public MailService(MailSettings mailSettings)
        {
            _mailSettings = mailSettings;
        }

        //método para enviar e-mail
        public void SendMail(string to, string subject, string body)
        {
            #region Criando o conteúdo do e-mail

            var mailMessage = new MailMessage(_mailSettings.Conta, to);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;

            #endregion

            #region Enviando o e-mail

            var smtpClient = new SmtpClient(_mailSettings.Smtp, _mailSettings.Porta);
            smtpClient.Credentials = new NetworkCredential(_mailSettings.Conta, _mailSettings.Senha);
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);

            #endregion
        }
    }
}
