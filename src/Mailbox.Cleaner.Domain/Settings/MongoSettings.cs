using System.Diagnostics.CodeAnalysis;

namespace Mailbox.Cleaner.Domain.Settings
{
    [ExcludeFromCodeCoverage]
    public class MongoSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public bool CreateIfNotExiste { get; set; }
        public int BatchSize { get; set; }
        public string CollectionEmail { get; set; }
        public string CollectionReport { get; set; }
    }
}
