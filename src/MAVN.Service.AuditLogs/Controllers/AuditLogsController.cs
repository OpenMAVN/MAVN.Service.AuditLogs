using AutoMapper;
using MAVN.Service.AuditLogs.Client;
using Microsoft.AspNetCore.Mvc;

namespace MAVN.Service.AuditLogs.Controllers
{
    [Route("api/AuditLogs")] // TODO fix route
    public class AuditLogsController : Controller, IAuditLogsApi
    {
        private readonly IMapper _mapper;

        public AuditLogsController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
