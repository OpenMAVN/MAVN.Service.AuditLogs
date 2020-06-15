using System.Threading.Tasks;
using JetBrains.Annotations;
using MAVN.Service.AuditLogs.Client.Models.Requests;
using MAVN.Service.AuditLogs.Client.Models.Responses;
using Refit;

namespace MAVN.Service.AuditLogs.Client
{
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
        [Get("/api/auditlogs")]
        Task<GetAuditLogsResponse> GetAuditLogsAsync([Query] GetAuditLogsRequest request);

        /// <summary>
        /// Add audit log
        /// </summary>
        /// <returns></returns>
        [Post("/api/auditlogs")]
        Task AddAuditLogAsync([Body] AddAuditLogRequest request);
    }
}
