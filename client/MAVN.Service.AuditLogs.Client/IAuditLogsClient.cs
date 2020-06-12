using JetBrains.Annotations;

namespace MAVN.Service.AuditLogs.Client
{
    /// <summary>
    /// AuditLogs client interface.
    /// </summary>
    [PublicAPI]
    public interface IAuditLogsClient
    {
        // Make your app's controller interfaces visible by adding corresponding properties here.
        // NO actual methods should be placed here (these go to controller interfaces, for example - IAuditLogsApi).
        // ONLY properties for accessing controller interfaces are allowed.

        /// <summary>Application Api interface</summary>
        IAuditLogsApi Api { get; }
    }
}
