namespace ApiEmpresas.Messages.Settings
{
    /// <summary>
    /// modelo de dados para capturar os parametros de envio de e-mail
    /// </summary>
    public class MailSettings
    {
        public string Conta { get; set; }
        public string Senha { get; set; }
        public string Smtp { get; set; }
        public int Porta { get; set; }
    }
}
