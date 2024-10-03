using FluentEmail.Core;
using FluentEmail.Models;

namespace FluentEmail.Services
{
    public class EmailService : IEmailService
    {
        private readonly IFluentEmail _fluentEmail;

        public EmailService(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail
                ?? throw new ArgumentNullException(nameof(fluentEmail));
        }
        public async Task SendAsync(EmailMetadata emailMetadata, CancellationToken cancellationToken = default)
        {
            var email = _fluentEmail
                .To(emailMetadata.ToAddress)
                .Subject(emailMetadata.Subject)
                .Body(emailMetadata.Body);

            var response = await email.SendAsync(cancellationToken);

            if (response.Successful)
            {
                Console.WriteLine("Email sent successfully!");
            }
            else
            {
                Console.WriteLine("Failed to send email: " + string.Join(", ", response.ErrorMessages));
            }
        }

        public async Task SendUsingTemplateAsync<T>(
            EmailMetadata emailMetadata, string template, T model, CancellationToken cancellationToken = default)
        {
            var email = _fluentEmail
                .To(emailMetadata.ToAddress)
                .Subject(emailMetadata.Subject)
                .UsingTemplate(template, model);

            var response = await email.SendAsync(cancellationToken);

            if (response.Successful)
            {
                Console.WriteLine("Email sent successfully!");
            }
            else
            {
                Console.WriteLine("Failed to send email: " + string.Join(", ", response.ErrorMessages));
            }
        }

        public async Task SendUsingTemplateFromFileAsync<T>(
            EmailMetadata emailMetadata, string filePath, T model, CancellationToken cancellationToken = default)
        {
            var email = _fluentEmail
                .To(emailMetadata.ToAddress)
                .Subject(emailMetadata.Subject)
                .UsingTemplateFromFile(filePath, model);

            var response = await email.SendAsync(cancellationToken);

            if (response.Successful)
            {
                Console.WriteLine("Email sent successfully!");
            }
            else
            {
                Console.WriteLine("Failed to send email: " + string.Join(", ", response.ErrorMessages));
            }
        }
    }
}
