using System.Collections.Generic;
using System.Threading.Tasks;
using Mailbox.Cleaner.Domain.Data.Documents;

namespace Mailbox.Cleaner.Domain.Data.Repository
{
    public interface IEmailRepository
    {
        Task<IDictionary<string, int>> GetUniqueDomain(string emailOwner);
        Task Add(EmailDocument document);
    }
}
