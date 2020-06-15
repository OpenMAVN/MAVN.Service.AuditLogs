using JetBrains.Annotations;
using Lykke.SettingsReader.Attributes;

namespace MAVN.Service.AuditLogs.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AuditLogsSettings
    {
        public DbSettings Db { get; set; }

        public RabbitMqSettings Rabbit { get; set; }
    }
}
