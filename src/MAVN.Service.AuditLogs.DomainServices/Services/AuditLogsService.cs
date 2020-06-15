using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Common.Log;
using MAVN.Service.AuditLogs.Domain.Models;
using MAVN.Service.AuditLogs.Domain.Repositories;
using MAVN.Service.AuditLogs.Domain.Services;

namespace MAVN.Service.AuditLogs.DomainServices.Services
{
    public class AuditLogsService : IAuditLogsService
    {
        private readonly IAuditLogsRepository _auditLogsRepository;
        private readonly ILog _log;

        public AuditLogsService(IAuditLogsRepository auditLogsRepository, ILogFactory logFactory)
        {
            _auditLogsRepository = auditLogsRepository;
            _log = logFactory.CreateLog(this);
        }

        public Task<(List<AuditLog> Logs, int Count)> GetListAsync(Guid? adminId, string actionType, DateTime? fromDate, DateTime? toDate, int currentPage, int pageSize)
        {
            var (skip, take) = ValidateAndCalculateSkipAndTake(currentPage, pageSize);
            return _auditLogsRepository.GetAsync(adminId, actionType, fromDate, toDate, skip, take);
        }

        public Task AddAsync(AuditLog auditLog)
        {
            if (auditLog.AdminUserId == default || string.IsNullOrEmpty(auditLog.ActionType) ||
                auditLog.Timestamp == default)
            {
                _log.Warning("Audit log with invalid or missing data", context: auditLog);
                throw new ArgumentException("Audit log with invalid or missing data");
            }

            return _auditLogsRepository.AddAsync(auditLog);
        }

        private (int skip, int take) ValidateAndCalculateSkipAndTake(int currentPage, int pageSize)
        {
            if (currentPage < 1)
                throw new ArgumentException("Current page must be positive", nameof(currentPage));

            if (pageSize < 1)
                throw new ArgumentException("Page size must be positive", nameof(pageSize));

            var skip = (currentPage - 1) * pageSize;
            var take = pageSize;

            return (skip, take);
        }
    }
}
