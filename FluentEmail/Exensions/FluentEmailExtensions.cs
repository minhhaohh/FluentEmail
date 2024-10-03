using FluentEmail.Core.Interfaces;
using FluentEmail.Models;
using FluentEmail.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FluentEmail.Exensions
{
    public static class FluentEmailExtensions
    {
        public static FluentEmailServicesBuilder AddOAuth2MailKitSender(this FluentEmailServicesBuilder builder, OAuth2SmtpClientOptions smtpClientOptions)
        {
            builder.Services.TryAdd(ServiceDescriptor.Scoped((Func<IServiceProvider, ISender>)((IServiceProvider _) => new OAuth2MailkitSender(smtpClientOptions))));
            return builder;
        }
    }
}
