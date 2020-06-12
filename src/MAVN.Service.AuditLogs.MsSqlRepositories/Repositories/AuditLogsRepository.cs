using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lykke.Common.MsSql;
using MAVN.Service.AuditLogs.Domain.Repositories;
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
    }
}
