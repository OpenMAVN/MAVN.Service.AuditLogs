using System;
using System.ComponentModel.DataAnnotations;
using MAVN.Service.AuditLogs.Client.Models.Enums;

namespace MAVN.Service.AuditLogs.Client.Models.Requests
{
    /// <summary>
    /// Request to add audit log
    /// </summary>
    public class AddAuditLogRequest
    {
        /// <summary>
        /// Id of the admin user
        /// </summary>
        [Required]
        public Guid AdminUserId { get; set; }
        /// <summary>
        /// Action contex in json format
        /// </summary>
        public string ActionContextJson { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [Required]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Action type
        /// </summary>
        [Required]
        public ActionType ActionType { get; set; }
    }
}
