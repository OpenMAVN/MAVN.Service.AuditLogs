using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MAVN.Service.AuditLogs.Domain.Models;
using MAVN.Service.AuditLogs.Domain.Models.Enums;
using MAVN.Service.AuditLogs.Domain.Repositories;
using MAVN.Service.AuditLogs.Domain.Services;

namespace MAVN.Service.AuditLogs.DomainServices.Services
{
    public class AuditLogsService : IAuditLogsService
    {
        private readonly IAuditLogsRepository _auditLogsRepository;

        public AuditLogsService(IAuditLogsRepository auditLogsRepository)
        {
            _auditLogsRepository = auditLogsRepository;
        }

        public Task<(List<AuditLog> Logs, int Count)> GetListAsync(Guid? adminId, ActionType? actionType, DateTime? fromDate, DateTime? toDate, int currentPage, int pageSize)
        {
            var (skip, take) = ValidateAndCalculateSkipAndTake(currentPage, pageSize);
            return _auditLogsRepository.GetAsync(adminId, actionType, fromDate, toDate, skip, take);
        }

        public Task AddAsync(AuditLog auditLog)
           => _auditLogsRepository.AddAsync(auditLog);

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
