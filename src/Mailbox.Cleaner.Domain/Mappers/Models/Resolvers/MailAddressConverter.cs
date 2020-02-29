using AutoMapper;
using Mailbox.Cleaner.Domain.Models;

namespace Mailbox.Cleaner.Domain.Mappers.Models.Resolvers
{
    public class MailAddressConverter : IValueConverter<string, MailAddress>
    {
        public MailAddress Convert(string sourceMember, ResolutionContext context)
        {
            var splitEmail = sourceMember.Split("@", System.StringSplitOptions.RemoveEmptyEntries);
            var splitDomain = splitEmail[1].Split(".", System.StringSplitOptions.RemoveEmptyEntries);

            return new MailAddress
            {
                Email = sourceMember,
                User = splitEmail[0],
                Domain = splitEmail[1],
                RootDomain = splitDomain[splitDomain.Length - 2] + "." + splitDomain[splitDomain.Length - 1]
            };
        }
    }
}
