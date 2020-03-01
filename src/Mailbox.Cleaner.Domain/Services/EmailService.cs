using System;
using System.Threading.Tasks;
using AutoMapper;
using Mailbox.Cleaner.Domain.Data.Documents;
using Mailbox.Cleaner.Domain.Data.Repository;
using Mailbox.Cleaner.Domain.Exceptions;
using Mailbox.Cleaner.Domain.Models;
using Mailbox.Cleaner.Domain.Requests;
using MailKit.Net.Pop3;

namespace Mailbox.Cleaner.Domain.Services
{
    public class EmailService : IEmailService
    {
        private readonly IMapper _mapper;
        private readonly IEmailRepository _emailRepository;

        public EmailService(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task Import(ImportRequest importRequest, IProgress<ProgressReport> progress)
        {
            //using var client = GetClient(importRequest);
            var elements = 100;//client.GetMessageCount();

            var report = new ProgressReport
            {
                TotalProgressAmount = elements
            };

            for (int i = 0; i < elements; i++)
            {
                System.Threading.Thread.Sleep(2000);
                report.CurrentProgressAmount++;
                progress.Report(report);
            }
            //await Processing(client, elements, async (email) =>
            //{
            //var document = _mapper.Map<EmailDocument>(email);
            //await _emailRepository.Add(document);
            //report.CurrentProgressAmount++;
            //progress.Report(report);
            //});

            return Task.CompletedTask;
        }

        private async Task Processing(IPop3Client client, int elements, Func<MailMessage, Task> process)
        {
            try
            {
                for (int i = 0; i < elements; i++)
                {
                    await process(_mapper.Map<MailMessage>(client.GetMessage(i)));
                }
            }
            catch
            {
                throw new MailProtocolException();
            }
        }

        public bool ValidSettings(ImportRequest importRequest)
        {
            try
            {
                using var client = GetClient(importRequest);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private IPop3Client GetClient(ImportRequest importRequest)
        {
            try
            {
                var mailClient = new Pop3Client();
                mailClient.Connect(importRequest.Server, importRequest.Port);
                mailClient.Authenticate(importRequest.Username, importRequest.Password);
                return mailClient;
            }
            catch
            {
                throw new MailProtocolException();
            }
        }
    }
}
