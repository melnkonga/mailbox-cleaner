using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox.Cleaner.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class MailMessage
    {
        public string Id { get; set; }
        public MailAddress From { get; set; }
        public MailAddress To { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string HtmlBody { get; set; }
        public string TextBody { get; set; }
    }
}
