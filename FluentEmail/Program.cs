using FluentEmail.Exensions;
using FluentEmail.Models;
using FluentEmail.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluentEmail
{
    class Program
    {
        public static IConfiguration Configuration;

        private static async Task Main(string[] args)
        {
            var services = ConfigureServices();

            try
            {
                var serviceProvider = services.BuildServiceProvider();
                var emailService = serviceProvider.GetRequiredService<IEmailService>();

                var data = new EmailMetadata("hao.tran@devsoft.vn", "Test Fluent Email", "Test Fluent Email");
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "TestTemplate.liquid");
                var model = new Person()
                {
                    Name = "Hao Tran",
                    Dob = new DateTime(2000, 12, 4),
                    Gender = "Male",
                    Address = "Ho Chi Minh city"
                };
                await emailService.SendUsingTemplateFromFileAsync(data, filePath, model);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private static ServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddScoped<IEmailService, EmailService>();

            var options = new OAuth2SmtpClientOptions()
            {
                Server = "smtp.gmail.com",
                Port = 465,
                User = "haotrandevsoft@gmail.com",
                ClientId = "",
                ClientSecret = "",
                UseSsl = true,
            };

            services.AddFluentEmail(options.User)
                .AddOAuth2MailKitSender(options)
                .AddLiquidRenderer();

            return services;
        }
    }
}