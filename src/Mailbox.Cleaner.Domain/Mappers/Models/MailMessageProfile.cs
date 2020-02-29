using System.Linq;
using AutoMapper;
using Mailbox.Cleaner.Domain.Mappers.Models.Resolvers;
using Mailbox.Cleaner.Domain.Models;
using MimeKit;

namespace Mailbox.Cleaner.Domain.Mappers.Models
{
    public class MailMessageProfile : Profile
    {
        public MailMessageProfile()
        {
            CreateMap<MimeMessage, MailMessage>()
                .ForMember(m => m.Id, m => m.MapFrom(p => p.MessageId))
                .ForMember(m => m.From, m => m.ConvertUsing<MailAddressConverter, string>(p => p.From.Mailboxes.First().Address))
                .ForMember(m => m.To, m => m.ConvertUsing<MailAddressConverter, string>(p => p.To.Mailboxes.First().Address))
                .ForMember(m => m.Date, m => m.MapFrom(p => p.Date.DateTime))
                .ForMember(m => m.Subject, m => m.MapFrom(p => p.Subject))
                .ForMember(m => m.HtmlBody, m => m.MapFrom(p => p.HtmlBody))
                .ForMember(m => m.TextBody, m => m.MapFrom(p => p.TextBody));
        }
    }
}
