using FluentAssertions;
using Mailbox.Cleaner.Domain.Mappers.Models.Resolvers;
using Xunit;

namespace Mailbox.Cleaner.Domain.Tests.Mappers.Models.Resolvers
{
    public class MailAdressConverterTests
    {
        private readonly MailAddressConverter _mailAdressResolver;

        public MailAdressConverterTests()
        {
            _mailAdressResolver = new MailAddressConverter();
        }

        [Theory]
        [InlineData("test@domain.com", "domain.com")]
        [InlineData("test@sub.domain.com", "domain.com")]
        [InlineData("test.example@sub.domain.com", "domain.com")]
        [InlineData("test.example@sub.sub.domain.com", "domain.com")]
        public void AutoMapper_ResolverRootDomain_IsValid(string email, string rootDomain)
        {
            var result = _mailAdressResolver.Convert(email, null);
            result.RootDomain.Should().BeEquivalentTo(rootDomain);
        }

        [Theory]
        [InlineData("test@domain.com", "domain.com")]
        [InlineData("test@sub.domain.com", "sub.domain.com")]
        [InlineData("test@sub.sub.domain.com", "sub.sub.domain.com")]
        public void AutoMapper_ResolverDomain_IsValid(string email, string domain)
        {
            var result = _mailAdressResolver.Convert(email, null);
            result.Domain.Should().BeEquivalentTo(domain);
        }
    }
}
