﻿using AutoReferenceSystem.ApplicationServer.Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace AutoReferenceSystem.ApplicationServer.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services
                .AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(ApplicationModule).Assembly))
                .AddTransient<ILoadBalanser, LoadBalanser>();
            return services;
        }
    }
}
