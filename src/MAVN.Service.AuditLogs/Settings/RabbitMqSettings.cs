using Lykke.SettingsReader.Attributes;

namespace MAVN.Service.AuditLogs.Settings
{
    public class RabbitMqSettings
    {
        public RabbitMqExchangeSettings Subscribers { get; set; }
        public RabbitMqExchangeSettings Publishers { get; set; }
    }

    public class RabbitMqExchangeSettings
    {
        [AmqpCheck]
        public string ConnectionString { get; set; }
    }
}
