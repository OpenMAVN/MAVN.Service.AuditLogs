using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MAVN.Service.AuditLogs.Domain.Models;

namespace MAVN.Service.AuditLogs.Domain.Services
{
    public interface IAuditLogsService
    {
        Task<(List<AuditLog> Logs, int Count)> GetListAsync(Guid? adminId, string actionType,
            DateTime? fromDate, DateTime? toDate, int currentPage, int pageSize);
        Task AddAsync(AuditLog auditLog);
    }
}
