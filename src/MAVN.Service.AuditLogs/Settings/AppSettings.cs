using JetBrains.Annotations;
using Lykke.Sdk.Settings;

namespace MAVN.Service.AuditLogs.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public AuditLogsSettings AuditLogsService { get; set; }
    }
}
