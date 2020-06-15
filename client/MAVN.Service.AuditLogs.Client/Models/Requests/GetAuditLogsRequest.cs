using System;

namespace MAVN.Service.AuditLogs.Client.Models.Requests
{
    /// <summary>
    /// Request model to get audit logs
    /// </summary>
    public class GetAuditLogsRequest : BasePagedModel
    {
        /// <summary>
        /// From date used for filtering
        /// </summary>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// To date used for filtering
        /// </summary>
        public DateTime? ToDate { get; set; }
        /// <summary>
        /// Admin id used for filtering
        /// </summary>
        public Guid? AdminId { get; set; }
        /// <summary>
        /// Action type used for filtering
        /// </summary>
        public string  ActionType { get; set; }
    }
}
