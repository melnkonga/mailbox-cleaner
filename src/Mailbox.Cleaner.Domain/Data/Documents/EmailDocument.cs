using System;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Mailbox.Cleaner.Domain.Data.Documents
{
    public class EmailDocument : DocumentBase
    {
        [BsonElement(nameof(From))]
        [JsonProperty(nameof(From))]
        public EmailAddressDocument From { get; set; }

        [BsonElement(nameof(To))]
        [JsonProperty(nameof(To))]
        public EmailAddressDocument To { get; set; }

        [BsonElement(nameof(Date))]
        [JsonProperty(nameof(Date))]
        public DateTime Date { get; set; }

        [BsonElement(nameof(Subject))]
        [JsonProperty(nameof(Subject))]
        public string Subject { get; set; }

        [BsonElement(nameof(HtmlBody))]
        [JsonProperty(nameof(HtmlBody))]
        public string HtmlBody { get; set; }

        [BsonElement(nameof(TextBody))]
        [JsonProperty(nameof(TextBody))]
        public string TextBody { get; set; }
    }
}
