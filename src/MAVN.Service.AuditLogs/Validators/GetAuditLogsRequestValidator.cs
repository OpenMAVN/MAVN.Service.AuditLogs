using FluentValidation;
using MAVN.Service.AuditLogs.Client.Models.Requests;

namespace MAVN.Service.AuditLogs.Validators
{
    public class GetAuditLogsRequestValidator : AbstractValidator<GetAuditLogsRequest>
    {
        public GetAuditLogsRequestValidator()
        {
            RuleFor(x => x.FromDate)
                .NotNull()
                .NotEmpty()
                .When(x => x.ToDate.HasValue && x.ToDate.Value != default);

            RuleFor(x => x.ToDate)
                .NotNull()
                .NotEmpty()
                .GreaterThan(x => x.FromDate)
                .When(x => x.FromDate.HasValue && x.FromDate.Value != default);
        }
    }
}
