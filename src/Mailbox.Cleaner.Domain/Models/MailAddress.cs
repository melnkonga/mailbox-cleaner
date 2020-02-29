using System.Diagnostics.CodeAnalysis;

namespace Mailbox.Cleaner.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class MailAddress
    {
        public string Email { get; set; }
        public string User { get; set; }
        public string Domain { get; set; }
        public string RootDomain { get; set; }
    }
}
