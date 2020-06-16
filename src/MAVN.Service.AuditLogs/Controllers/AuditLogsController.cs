using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MAVN.Service.AuditLogs.Client;
using MAVN.Service.AuditLogs.Client.Models.Requests;
using MAVN.Service.AuditLogs.Client.Models.Responses;
using MAVN.Service.AuditLogs.Domain.Models;
using MAVN.Service.AuditLogs.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MAVN.Service.AuditLogs.Controllers
{
    [Route("api/auditlogs")]
    public class AuditLogsController : Controller, IAuditLogsApi
    {
        private readonly IAuditLogsService _auditLogsService;
        private readonly IMapper _mapper;

        public AuditLogsController(IAuditLogsService auditLogsService, IMapper mapper)
        {
            _auditLogsService = auditLogsService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets paged audit logs
        /// </summary>
        /// <returns><see cref="GetAuditLogsResponse"/></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetAuditLogsResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<GetAuditLogsResponse> GetAuditLogsAsync([FromQuery] GetAuditLogsRequest request)
        {
            var result = await _auditLogsService.GetListAsync(request.AdminId, request.ActionType, request.FromDate,
                request.ToDate, request.CurrentPage, request.PageSize);

            return new GetAuditLogsResponse
            {
                Logs = _mapper.Map<List<AuditLogResponse>>(result.Logs),
                TotalCount = result.Count,
            };
        }

        /// <summary>
        /// Add audit log
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task AddAuditLogAsync([FromBody] AddAuditLogRequest request)
        {
            var model = _mapper.Map<AuditLog>(request);
            await _auditLogsService.AddAsync(model);
        }
    }
}
