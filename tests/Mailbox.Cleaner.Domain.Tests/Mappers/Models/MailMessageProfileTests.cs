using AutoMapper;
using Mailbox.Cleaner.Domain.Mappers.Models;
using Xunit;

namespace Mailbox.Cleaner.Domain.Tests.Mappers.Models
{
    public class MailMessageProfileTests
    {
        private readonly MailMessageProfile _mailMessageProfile;
        private readonly MapperConfiguration _mapperConfiguration;

        public MailMessageProfileTests()
        {
            _mailMessageProfile = new MailMessageProfile();
            _mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(_mailMessageProfile));
        }

        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            _mapperConfiguration.AssertConfigurationIsValid();
        }
    }
}
