using System;
using MAVN.Service.AuditLogs.Domain.Models.Enums;

namespace MAVN.Service.AuditLogs.Domain.Models
{
    public class AuditLog
    {
        public Guid AdminUserId { get; set; }
        public string ActionContextJson { get; set; }
        public DateTime Timestamp { get; set; }
        public ActionType ActionType { get; set; }
    }
}
