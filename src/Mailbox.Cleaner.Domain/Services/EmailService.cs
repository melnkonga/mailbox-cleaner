using System;
using System.Threading.Tasks;
using AutoMapper;
using Mailbox.Cleaner.Domain.Exceptions;
using Mailbox.Cleaner.Domain.Models;
using Mailbox.Cleaner.Domain.Settings;
using MailKit.Net.Pop3;

namespace Mailbox.Cleaner.Domain.Services
{
    public class EmailService : IEmailService
    {
        private readonly IMapper _mapper;

        public EmailService(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Processing(PopSettings popSettings, Func<MailMessage, Task> process)
        {
            try
            {
                using var client = GetClient(popSettings);
                var count = client.GetMessageCount();

                for (int i = 0; i < count; i++)
                {
                    await process(_mapper.Map<MailMessage>(client.GetMessage(i)));
                }
            }
            catch
            {
                throw new MailProtocolException();
            }
        }

        public bool ValidSettings(PopSettings popSettings)
        {
            try
            {
                using var client = GetClient(popSettings);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private IPop3Client GetClient(PopSettings popSettings)
        {
            try
            {
                var mailClient = new Pop3Client();
                mailClient.Connect(popSettings.Server, popSettings.Port);
                mailClient.Authenticate(popSettings.Username, popSettings.Password);
                return mailClient;
            }
            catch
            {
                throw new MailProtocolException();
            }
        }
    }
}
