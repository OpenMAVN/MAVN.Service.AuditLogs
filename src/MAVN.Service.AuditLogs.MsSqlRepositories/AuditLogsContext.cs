﻿using System.Data.Common;
using JetBrains.Annotations;
using MAVN.Persistence.PostgreSQL.Legacy;
using MAVN.Service.AuditLogs.MsSqlRepositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAVN.Service.AuditLogs.MsSqlRepositories
{
    public class AuditLogsContext : PostgreSQLContext
    {
        private const string Schema = "audit_logs";

        public DbSet<AuditLogEntity> AuditLogs { get; set; }

        // empty constructor needed for EF migrations
        [UsedImplicitly]
        public AuditLogsContext()
            : base(Schema)
        {
        }

        public AuditLogsContext(string connectionString, bool isTraceEnabled)
            : base(Schema, connectionString, isTraceEnabled)
        {
        }

        //Needed constructor for using InMemoryDatabase for tests
        public AuditLogsContext(DbContextOptions options)
            : base(Schema, options)
        {
        }

        public AuditLogsContext(DbConnection dbConnection)
            : base(Schema, dbConnection)
        {
        }

        protected override void OnMAVNModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditLogEntity>().HasIndex(x => x.ActionType).IsUnique(false);
            modelBuilder.Entity<AuditLogEntity>().HasIndex(x => x.AdminUserId).IsUnique(false);
            modelBuilder.Entity<AuditLogEntity>().HasIndex(x => x.Date).IsUnique(false);
        }
    }
}
