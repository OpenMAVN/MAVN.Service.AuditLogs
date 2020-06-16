using Autofac;
using JetBrains.Annotations;
using Lykke.RabbitMqBroker.Publisher;
using Lykke.RabbitMqBroker.Subscriber;
using Lykke.SettingsReader;
using MAVN.Service.AuditLogs.Contract.Events;
using MAVN.Service.AuditLogs.Domain.Models;
using MAVN.Service.AuditLogs.DomainServices.RabbitMq.Subscribers;
using MAVN.Service.AuditLogs.Settings;

namespace MAVN.Service.AuditLogs.Modules
{
    [UsedImplicitly]
    public class RabbitMqModule : Module
    {
        private const string AuditLogSubExchangeName = "lykke.customer.auditlogcreate";

        private readonly RabbitMqSettings _settings;

        public RabbitMqModule(IReloadingManager<AppSettings> settingsManager)
        {
            _settings = settingsManager.CurrentValue.AuditLogsService.Rabbit;
        }

        protected override void Load(ContainerBuilder builder)
        {
            RegisterRabbitMqSubscribers(builder);
        }

        private void RegisterRabbitMqSubscribers(ContainerBuilder builder)
        {
            builder.RegisterJsonRabbitSubscriber<AuditLogEventSubscriber, AuditLogEvent>(
                _settings.Subscribers.ConnectionString,
                AuditLogSubExchangeName,
                nameof(AuditLog).ToLower());
        }
    }
}
