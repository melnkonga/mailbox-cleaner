using System;
namespace Mailbox.Cleaner.Domain.Exceptions
{
    public class MailProtocolException : Exception
    {
        public MailProtocolException() : base("Can't connect to POP server, check POP server settings")
        {
        }
    }
}
