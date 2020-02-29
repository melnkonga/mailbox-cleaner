using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using Newtonsoft.Json;

namespace Mailbox.Cleaner.Domain.Data.Documents
{
    public class ReportDocument : DocumentBase
    {
        [BsonElement(nameof(UniqueDomain)), BsonDictionaryOptions(DictionaryRepresentation.ArrayOfDocuments)]
        [JsonProperty(nameof(UniqueDomain))]
        public IDictionary<string, int> UniqueDomain = new Dictionary<string, int>();

        [BsonElement(nameof(Date))]
        [JsonProperty(nameof(Date))]
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
