using System.Threading.Tasks;
using Mailbox.Cleaner.Domain.Settings;

namespace Mailbox.Cleaner.Domain.Services
{
    public interface IImportService
    {
        Task ImportEmails(PopSettings popSettings);
    }
}
