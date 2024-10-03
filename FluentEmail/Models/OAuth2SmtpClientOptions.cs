using FluentEmail.MailKitSmtp;

namespace FluentEmail.Models
{
    public class OAuth2SmtpClientOptions : SmtpClientOptions
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}
