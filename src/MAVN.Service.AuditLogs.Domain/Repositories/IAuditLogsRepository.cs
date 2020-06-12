using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MAVN.Service.AuditLogs.Domain.Models;
using MAVN.Service.AuditLogs.Domain.Models.Enums;

namespace MAVN.Service.AuditLogs.Domain.Repositories
{
    public interface IAuditLogsRepository
    {
        Task AddAsync(AuditLog model);
        Task<(List<AuditLog> Logs, int Count)> GetAsync(Guid? adminId, ActionType? actionType, DateTime? fromDate, DateTime? toDate, int skip, int take);
    }
}
