using System.Diagnostics.CodeAnalysis;

namespace Mailbox.Cleaner.Domain.Settings
{
    [ExcludeFromCodeCoverage]
    public class PopSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
