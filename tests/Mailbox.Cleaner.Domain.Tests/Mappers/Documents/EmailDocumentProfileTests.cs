using System;
using AutoMapper;
using FluentAssertions;
using Mailbox.Cleaner.Domain.Data.Documents;
using Mailbox.Cleaner.Domain.Mappers.Documents;
using Mailbox.Cleaner.Domain.Models;
using Xunit;

namespace Mailbox.Cleaner.Domain.Tests.Mappers.Documents
{
    public class EmailDocumentProfileTests
    {
        private readonly EmailDocumentProfile _emailDocumentProfile;
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IMapper _mapper;

        public EmailDocumentProfileTests()
        {
            _emailDocumentProfile = new EmailDocumentProfile();
            _mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(_emailDocumentProfile));
            _mapper = new Mapper(_mapperConfiguration);
        }

        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            _mapperConfiguration.AssertConfigurationIsValid();
        }

        [Fact]
        public void AutoMapper_MapMessage_Valid()
        {
            // A
            const string Subject = "subject";
            const string HtmlBody = "html";
            const string TextBody = "text";
            DateTime date = DateTime.Now;
            MailAddress mailAddress = new MailAddress
            {
                Domain = "domain.com",
                RootDomain = "domain.com",
                Email = "test@domain.com",
                User = "test"
            };

            // A
            var result = _mapper.Map<EmailDocument>(new MailMessage{
                Date = date,
                From = mailAddress,
                To = mailAddress,
                HtmlBody = "html",
                TextBody = "text",
                Subject = "subject",
                Id = "123"
            });

            // A
            result.Should().NotBeNull();
            result.Id.Should().BeNull();

            result.From.Should().BeEquivalentTo(mailAddress);
            result.To.Should().BeEquivalentTo(mailAddress);

            result.HtmlBody.Should().BeEquivalentTo(HtmlBody);
            result.TextBody.Should().BeEquivalentTo(TextBody);
            result.Subject.Should().BeEquivalentTo(Subject);
        }
    }
}
