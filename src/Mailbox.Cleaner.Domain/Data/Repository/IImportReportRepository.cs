using System.Threading.Tasks;
using Mailbox.Cleaner.Domain.Data.Documents;

namespace Mailbox.Cleaner.Domain.Data.Repository
{
    public interface IImportReportRepository
    {
        Task<ImportReportDocument> AddOrUpdate(ImportReportDocument document);
        Task<ImportReportDocument> Complete(string documentId);
        Task<ImportReportDocument> Get(string reportId);
    }
}
