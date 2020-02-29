using AutoMapper;
using Mailbox.Cleaner.Domain.Data.Documents;
using Mailbox.Cleaner.Domain.Models;

namespace Mailbox.Cleaner.Domain.Mappers.Documents
{
    public class EmailDocumentProfile : Profile
    {
        public EmailDocumentProfile()
        {
            CreateMap<MailAddress, EmailAddressDocument>();

            CreateMap<MailMessage, EmailDocument>()
                .ForMember(m => m.Id, m => m.Ignore());
        }
    }
}
