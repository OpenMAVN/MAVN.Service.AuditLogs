using System.Data.Common;
using JetBrains.Annotations;
using Lykke.Common.MsSql;
using Microsoft.EntityFrameworkCore;

namespace MAVN.Service.AuditLogs.MsSqlRepositories
{
    public class AuditLogsContext : MsSqlContext
    {
        private const string Schema = ""; // TODO put proper schema name here

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

        protected override void OnLykkeModelCreating(ModelBuilder modelBuilder)
        {
            // TODO put db entities models building code here
        }
    }
}
