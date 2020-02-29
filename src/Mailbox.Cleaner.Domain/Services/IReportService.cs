using System.Threading.Tasks;

namespace Mailbox.Cleaner.Domain.Services
{
    public interface IReportService
    {
        Task<string> GenerateReport(string emailOwner);
    }
}
