
using AutoReferenceSystem.ApplicationServer.Application;
using AutoReferenceSystem.ApplicationServer.Data;
using AutoReferenceSystem.ApplicationServer.Data.DataProfiles.Base;
using AutoReferenceSystem.ApplicationServer.Data.DataProfiles;
using Microsoft.Extensions.Configuration;
using AutoReferenceSystem.ApplicationServer.SharedKernel.Interfaces;
using AutoReferenceSystem.ApplicationServer.SharedKernel;

namespace AutoReferenceSystem.ApplicationServer.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration configuration = builder.Configuration;

            IDataProfileFactory dataProfileFactory = new DataProfileFactory(configuration);
            DataProfile dataProfile = dataProfileFactory.CreateProfile();
            // Add services to the container.
            builder.Services.AddApplicationModule()
                .AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(Program).Assembly))
                .AddScoped<IDomainEventDispatcher, DomainEventDispatcher>()
                .AddDbContext<AutoReferenceSystemContext>(dataProfile.ConfigureDbContextOptionsBuilder)
                .AddHttpClient("", client =>
                {
                    //client.BaseAddress = new Uri("", UriKind.Absolute);
                });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AutoReferenceSystemContext>();
                dataProfile.UseDbContext(context);
            }

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors(builder => builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials());

            app.Run();
        }
    }
}
