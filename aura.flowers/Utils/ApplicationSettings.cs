namespace aura.flowers.Utils
{
    public class ApplicationSettings
    {
        public MailConfiguration MailConfiguration { get; set; }

        public GoogleReCaptcha GoogleReCaptcha { get; set; }
    }

    public class MailConfiguration
    {
        public string SmtpServer { get; set; }

        public int SmtpPort { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string MailFrom { get; set; }

        public string MailTo { get; set; }
    }

    public class GoogleReCaptcha
    {
        public string Key { get; set; }

        public string Secret { get; set; }
    }
}