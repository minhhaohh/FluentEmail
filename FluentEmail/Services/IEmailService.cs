using FluentEmail.Models;

namespace FluentEmail.Services
{
    public interface IEmailService
    {
        Task SendAsync(EmailMetadata emailMetadata, CancellationToken cancellationToken = default);

        Task SendUsingTemplateAsync<T>(
            EmailMetadata emailMetadata, string template, T model, CancellationToken cancellationToken = default)

        Task SendUsingTemplateFromFileAsync<T>(
            EmailMetadata emailMetadata, string filePath, T model, CancellationToken cancellationToken = default);
    }
}
