using System;
using MAVN.Service.AuditLogs.Client.Models.Enums;

namespace MAVN.Service.AuditLogs.Client.Models.Responses
{
    /// <summary>
    /// Response model for audit log
    /// </summary>
    public class AuditLogResponse
    {
        /// <summary>
        /// Id of the admin user
        /// </summary>
        public Guid AdminUserId { get; set; }
        /// <summary>
        /// Action contex in json format
        /// </summary>
        public string ActionContextJson { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Action type
        /// </summary>
        public ActionType ActionType { get; set; }
    }
}
