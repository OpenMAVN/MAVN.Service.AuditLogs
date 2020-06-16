using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MAVN.Service.AuditLogs.Domain.Models;

namespace MAVN.Service.AuditLogs.Domain.Repositories
{
    public interface IAuditLogsRepository
    {
        Task AddAsync(AuditLog model);
        Task<(List<AuditLog> Logs, int Count)> GetAsync(Guid? adminId, string actionType, DateTime? fromDate, DateTime? toDate, int skip, int take);
    }
}
