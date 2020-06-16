using System;
using Autofac;
using AutoMapper;
using JetBrains.Annotations;
using Lykke.Logs.Loggers.LykkeSlack;
using Lykke.Sdk;
using Lykke.Sdk.Health;
using Lykke.Sdk.Middleware;
using Lykke.SettingsReader;
using MAVN.Service.AuditLogs.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MAVN.Service.AuditLogs
{
    [UsedImplicitly]
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;
        private IReloadingManager<AppSettings> _settingsManager;

        private readonly LykkeSwaggerOptions _swaggerOptions = new LykkeSwaggerOptions
        {
            ApiTitle = "AuditLogs API",
            ApiVersion = "v1"
        };

        [UsedImplicitly]
        public void ConfigureServices(IServiceCollection services)
        {
            (_configurationRoot, _settingsManager) = services.BuildServiceProvider<AppSettings>(options =>
            {
                options.SwaggerOptions = _swaggerOptions;

                options.Logs = logs =>
                {
                    logs.AzureTableName = "AuditLogsLog";
                    logs.AzureTableConnectionStringResolver = settings => settings.AuditLogsService.Db.LogsConnString;
                };

                options.Extend = (sc, settings) =>
                {
                    sc.AddAutoMapper(typeof(AutoMapperProfile));
                };
            });
        }

        [UsedImplicitly]
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.ConfigureLykkeContainer(
                _configurationRoot,
                _settingsManager);
        }

        [UsedImplicitly]
        public void Configure(
            IApplicationBuilder app,
            IMapper mapper,
            IApplicationLifetime appLifetime)
        {
            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            app.UseLykkeConfiguration(appLifetime, options =>
            {
                options.SwaggerOptions = _swaggerOptions;
            });
        }
    }
}
