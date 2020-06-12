using System.Threading.Tasks;
using JetBrains.Annotations;
using MAVN.Service.AuditLogs.Client.Models.Requests;
using MAVN.Service.AuditLogs.Client.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace MAVN.Service.AuditLogs.Client
{
    // This is an example of service controller interfaces.
    // Actual interface methods must be placed here (not in IAuditLogsClient interface).

    /// <summary>
    /// AuditLogs client API interface.
    /// </summary>
    [PublicAPI]
    public interface IAuditLogsApi
    {

        /// <summary>
        /// Gets paged audit logs
        /// </summary>
        /// <returns><see cref="GetAuditLogsResponse"/></returns>
        [HttpGet("/api/auditlogs")]
        Task<GetAuditLogsResponse> GetAuditLogsAsync([Query] GetAuditLogsRequest request);

        /// <summary>
        /// Add audit log
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/auditlogs")]
        Task AddAuditLogAsync([Body] AddAuditLogRequest request);
    }
}
