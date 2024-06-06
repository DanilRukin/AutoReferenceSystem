using AntDesign.ProLayout;
using AutoReferenceSystem.WebClient.Infrastructure.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutoReferenceSystem.WebClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            IConfiguration configuration = builder.Configuration;

            builder.Services.AddSingleton<CurrentUserData>();

            builder.Services.AddHttpClient("", client =>
            {
                client.BaseAddress = new Uri(configuration["ApiBaseAddress"], UriKind.Absolute);
            });
            builder.Services.AddAntDesign();
            builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
            builder.Services.AddTransient<IMessageNotificator, MessageNotificator>();

            await builder.Build().RunAsync();
        }
    }
}