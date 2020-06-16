using System;

namespace MAVN.Service.AuditLogs.Contract.Events
{
    /// <summary>
    /// Event used to add audit log
    /// </summary>
    public class AuditLogEvent
    {
        /// <summary>
        /// Id of the admin user
        /// </summary>
        public Guid AdminUserId { get; set; }

        /// <summary>
        /// Action type
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Action context
        /// </summary>
        public string ActionContextJson { get; set; }
    }
}
