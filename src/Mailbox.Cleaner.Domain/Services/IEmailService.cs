using System;
using System.Threading.Tasks;
using Mailbox.Cleaner.Domain.Models;
using Mailbox.Cleaner.Domain.Requests;

namespace Mailbox.Cleaner.Domain.Services
{
    public interface IEmailService
    {
        bool ValidSettings(ImportRequest popSettings);

        /// <exception cref="MailProtocolException"></exception>
        Task Import(ImportRequest importRequest, IProgress<ProgressReport> progress);
    }
}
