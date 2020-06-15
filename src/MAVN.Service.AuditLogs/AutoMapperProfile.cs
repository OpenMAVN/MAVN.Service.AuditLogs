using AutoMapper;
using MAVN.Service.AuditLogs.Client.Models.Requests;
using MAVN.Service.AuditLogs.Client.Models.Responses;
using MAVN.Service.AuditLogs.Domain.Models;

namespace MAVN.Service.AuditLogs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AuditLog, AuditLogResponse>();
            CreateMap<AddAuditLogRequest, AuditLog>();
        }
    }
}
