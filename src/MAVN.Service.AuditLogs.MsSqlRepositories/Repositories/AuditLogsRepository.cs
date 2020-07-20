using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAVN.Persistence.PostgreSQL.Legacy;
using MAVN.Service.AuditLogs.Domain.Models;
using MAVN.Service.AuditLogs.Domain.Repositories;
using MAVN.Service.AuditLogs.MsSqlRepositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAVN.Service.AuditLogs.MsSqlRepositories.Repositories
{
    public class AuditLogsRepository : IAuditLogsRepository
    {
        private readonly IDbContextFactory<AuditLogsContext> _contextFactory;

        public AuditLogsRepository(IDbContextFactory<AuditLogsContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task AddAsync(AuditLog model)
        {
            var entity = AuditLogEntity.Create(model);
            using (var context = _contextFactory.CreateDataContext())
            {
                context.AuditLogs.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<(List<AuditLog> Logs, int Count)> GetAsync(Guid? adminId, string actionType, DateTime? fromDate, DateTime? toDate, int skip, int take)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var query = context.AuditLogs.AsNoTracking();

                if (fromDate.HasValue && toDate.HasValue)
                    query = query.Where(x =>
                        x.Date >= fromDate.Value && x.Date <= toDate.Value && x.Timestamp >= fromDate.Value &&
                        x.Timestamp <= toDate.Value);

                if (adminId.HasValue)
                    query = query.Where(x => x.AdminUserId == adminId.Value);

                if (!string.IsNullOrEmpty(actionType))
                    query = query.Where(x => x.ActionType == actionType);

                var count = await query.CountAsync();

                var logs = await query
                    .Skip(skip)
                    .Take(take)
                    .Select(x => new AuditLog
                    {
                        AdminUserId = x.AdminUserId,
                        ActionType = x.ActionType,
                        ActionContextJson = x.ActionContextJson,
                        Timestamp = x.Timestamp
                    })
                    .OrderByDescending(x => x.Timestamp)
                    .ToListAsync();

                return (logs, count);
            }
        }
    }
}
