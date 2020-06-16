using System;

namespace MAVN.Service.AuditLogs.Domain.Models
{
    public class AuditLog
    {
        public Guid AdminUserId { get; set; }
        public string ActionContextJson { get; set; }
        public DateTime Timestamp { get; set; }
        public string ActionType { get; set; }
    }
}
