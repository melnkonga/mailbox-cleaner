using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Mailbox.Cleaner.Domain.Data.Documents
{
    public class ImportReportDocument : DocumentBase
    {
        [BsonElement(nameof(Date))]
        [JsonProperty(nameof(Date))]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [BsonElement(nameof(Owner))]
        [JsonProperty(nameof(Owner))]
        public string Owner { get; set; }

        [BsonElement(nameof(Elements))]
        [JsonProperty(nameof(Elements))]
        public int Elements { get; set; } = 0;

        [BsonElement(nameof(Errors))]
        [JsonProperty(nameof(Errors))]
        public IList<string> Errors = new List<string>();

        [BsonElement(nameof(Completed))]
        [JsonProperty(nameof(Completed))]
        public bool Completed { get; set; } = false;
    }
}
