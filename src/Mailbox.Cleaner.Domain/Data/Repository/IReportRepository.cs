using System.Collections.Generic;
using System.Threading.Tasks;
using Mailbox.Cleaner.Domain.Data.Documents;

namespace Mailbox.Cleaner.Domain.Data.Repository
{
    public interface IReportRepository
    {
        Task Add(ReportDocument document);
        Task<IList<ReportDocument>> Get();
        Task<ReportDocument> Get(string reportId);
    }
}
