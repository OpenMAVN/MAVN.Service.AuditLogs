using System.Threading.Tasks;
using Lykke.Common.Log;
using Lykke.RabbitMqBroker.Subscriber;
using MAVN.Service.AuditLogs.Contract.Events;
using MAVN.Service.AuditLogs.Domain.Models;
using MAVN.Service.AuditLogs.Domain.Services;

namespace MAVN.Service.AuditLogs.DomainServices.RabbitMq.Subscribers
{
    public class AuditLogEventSubscriber : JsonRabbitSubscriber<AuditLogEvent>
    {
        private readonly IAuditLogsService _auditLogsService;

        public AuditLogEventSubscriber(
            IAuditLogsService auditLogsService,
            string connectionString,
            string exchangeName,
            string queueName,
            ILogFactory logFactory) : base(connectionString, exchangeName, queueName, logFactory)
        {
            _auditLogsService = auditLogsService;
        }


        protected override async Task ProcessMessageAsync(AuditLogEvent message)
        {
            await _auditLogsService.AddAsync(new AuditLog
            {
                ActionType = message.ActionType,
                AdminUserId = message.AdminUserId,
                ActionContextJson = message.ActionContextJson,
                Timestamp = message.Timestamp,
            });
        }
    }
}
