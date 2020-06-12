using Lykke.HttpClientGenerator;

namespace MAVN.Service.AuditLogs.Client
{
    /// <summary>
    /// AuditLogs API aggregating interface.
    /// </summary>
    public class AuditLogsClient : IAuditLogsClient
    {
        // Note: Add similar Api properties for each new service controller

        /// <summary>Inerface to AuditLogs Api.</summary>
        public IAuditLogsApi Api { get; private set; }

        /// <summary>C-tor</summary>
        public AuditLogsClient(IHttpClientGenerator httpClientGenerator)
        {
            Api = httpClientGenerator.Generate<IAuditLogsApi>();
        }
    }
}
