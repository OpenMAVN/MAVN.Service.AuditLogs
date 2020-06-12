using Lykke.SettingsReader.Attributes;

namespace MAVN.Service.AuditLogs.Client 
{
    /// <summary>
    /// AuditLogs client settings.
    /// </summary>
    public class AuditLogsServiceClientSettings 
    {
        /// <summary>Service url.</summary>
        [HttpCheck("api/isalive")]
        public string ServiceUrl {get; set;}
    }
}
