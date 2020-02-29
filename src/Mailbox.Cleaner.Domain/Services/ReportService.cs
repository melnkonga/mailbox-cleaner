using System;
using System.Threading.Tasks;
using Mailbox.Cleaner.Domain.Data.Documents;
using Mailbox.Cleaner.Domain.Data.Repository;
using Microsoft.Extensions.Logging;

namespace Mailbox.Cleaner.Domain.Services
{
    public class ReportService : IReportService
    {
        private readonly ILogger<ReportService> _logger;
        private readonly IEmailRepository _emailRepository;
        private readonly IReportRepository _reportRepository;

        public ReportService(ILogger<ReportService> logger, IEmailRepository emailRepository, IReportRepository reportRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _emailRepository = emailRepository ?? throw new ArgumentNullException(nameof(emailRepository));
            _reportRepository = reportRepository ?? throw new ArgumentNullException(nameof(reportRepository));
        }

        public async Task<string> GenerateReport(string emailOwner)
        {
            _logger.LogTrace($"{ nameof(GenerateReport) } started for { emailOwner }");
            var report = new ReportDocument
            {
                UniqueDomain = await _emailRepository.GetUniqueDomain(emailOwner)
            };

            await _reportRepository.Add(report);

            _logger.LogTrace($"{ nameof(GenerateReport) } for { emailOwner } finished with id { report.Id }");
            return report.Id;
        }
    }
}
