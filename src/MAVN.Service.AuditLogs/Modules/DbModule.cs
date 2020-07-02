using Autofac;
using JetBrains.Annotations;
using Lykke.SettingsReader;
using MAVN.Persistence.PostgreSQL.Legacy;
using MAVN.Service.AuditLogs.Domain.Repositories;
using MAVN.Service.AuditLogs.MsSqlRepositories;
using MAVN.Service.AuditLogs.MsSqlRepositories.Repositories;
using MAVN.Service.AuditLogs.Settings;

namespace MAVN.Service.AuditLogs.Modules
{
    [UsedImplicitly]
    public class DbModule : Module
    {
        private readonly string _connectionString;

        public DbModule(IReloadingManager<AppSettings> appSettings)
        {
            _connectionString = appSettings.CurrentValue.AuditLogsService.Db.SqlDbConnString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuditLogsRepository>()
                .As<IAuditLogsRepository>()
                .SingleInstance();

            builder.RegisterPostgreSQL(
                _connectionString,
                connString => new AuditLogsContext(connString, false),
                dbConn => new AuditLogsContext(dbConn));
        }
    }
}
