﻿using CesarBmx.Shared.Api.Configuration;
using CryptoWatcher.Application.Automapper;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoWatcher.Api.Configuration
{
    public static class AutomapperConfig
    {
        public static IServiceCollection ConfigureAutomapper(this IServiceCollection services)
        {
            // Shared
            services.ConfigureSharedAutomapper(typeof(CurrencyMapping).Assembly);

            return services;
        }
    }
}
