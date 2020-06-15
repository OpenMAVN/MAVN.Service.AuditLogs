using System.Collections.Generic;

namespace MAVN.Service.AuditLogs.Client.Models.Responses
{
    /// <summary>
    /// Response model for audit logs
    /// </summary>
    public class GetAuditLogsResponse
    {
        /// <summary>
        /// List of logs
        /// </summary>
        public List<AuditLogResponse> Logs { get; set; }

        /// <summary>
        /// Logs total count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
