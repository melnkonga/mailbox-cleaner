using System;
using System.Threading.Tasks;
using AutoMapper;
using Mailbox.Cleaner.Domain.Data.Documents;
using Mailbox.Cleaner.Domain.Data.Repository;
using Mailbox.Cleaner.Domain.Settings;
using Microsoft.Extensions.Logging;

namespace Mailbox.Cleaner.Domain.Services
{
    public class ImportService : IImportService
    {
        private readonly ILogger<ImportService> _logger;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IEmailRepository _emailRepository;
        private readonly IImportReportRepository _importReportRepository;

        public ImportService(ILogger<ImportService> logger, IMapper mapper, IEmailService emailService, IEmailRepository emailRepository, IImportReportRepository importReportRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _emailRepository = emailRepository ?? throw new ArgumentNullException(nameof(emailRepository));
            _importReportRepository = importReportRepository ?? throw new ArgumentNullException(nameof(importReportRepository));
        }

        public async Task ImportEmails(PopSettings popSettings)
        {
            var report = await _importReportRepository.AddOrUpdate(new ImportReportDocument
            {
                Owner = popSettings.Username
            });

            await _emailService.Processing(popSettings, async (email) =>
            {
                try
                {
                    var document = _mapper.Map<EmailDocument>(email);
                    await _emailRepository.Add(document);
                    report.Elements++;
                } catch (Exception exception)
                {
                    report.Errors.Add(exception.Message);
                }

                await _importReportRepository.AddOrUpdate(report);
            });
        }
    }
}
