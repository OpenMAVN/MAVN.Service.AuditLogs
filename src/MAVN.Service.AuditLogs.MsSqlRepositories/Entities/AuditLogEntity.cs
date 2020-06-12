using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAVN.Service.AuditLogs.Domain.Models;
using MAVN.Service.AuditLogs.Domain.Models.Enums;

namespace MAVN.Service.AuditLogs.MsSqlRepositories.Entities
{
    [Table("audit_logs")]
    public class AuditLogEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("admin_user_id")]
        public Guid AdminUserId { get; set; }

        [Column("action_context")]
        public string ActionContextJson { get; set; }

        [Required]
        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        [Required]
        [Column("action_type")]
        public ActionType ActionType { get; set; }

        public static AuditLogEntity Create(AuditLog model)
        {
            return new AuditLogEntity
            {
                AdminUserId = model.AdminUserId,
                ActionContextJson = model.ActionContextJson,
                ActionType = model.ActionType,
                Timestamp = model.Timestamp,
            };
        }
    }
}
