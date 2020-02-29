using System;
using System.Threading.Tasks;
using Mailbox.Cleaner.Domain.Models;
using Mailbox.Cleaner.Domain.Settings;

namespace Mailbox.Cleaner.Domain.Services
{
    public interface IEmailService
    {
        /// <exception cref="MailProtocolException"></exception>
        Task Processing(PopSettings popSettings, Func<MailMessage, Task> process);

        bool ValidSettings(PopSettings popSettings);
    }
}
