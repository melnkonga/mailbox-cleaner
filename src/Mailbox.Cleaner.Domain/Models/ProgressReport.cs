using System.Diagnostics.CodeAnalysis;

namespace Mailbox.Cleaner.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class ProgressReport
    {
        public int CurrentProgressAmount { get; set; } = 0;
        public int TotalProgressAmount { get; set; } = 0;
        public string CurrentProgressMessage { get; set; }
        public bool OnError { get; set; } = false;
    }
}
