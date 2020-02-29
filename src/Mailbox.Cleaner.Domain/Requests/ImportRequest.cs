using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox.Cleaner.Domain.Requests
{
    [ExcludeFromCodeCoverage]
    public class ImportRequest
    {
        [Required]
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
