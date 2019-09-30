namespace aura.flowers.Utils
{
    public class ApplicationSettings
    {
        public MailConfiguration MailConfiguration { get; set; }
    }

    public class MailConfiguration
    {
        public string SmtpServer { get; set; }

        public int Port { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
