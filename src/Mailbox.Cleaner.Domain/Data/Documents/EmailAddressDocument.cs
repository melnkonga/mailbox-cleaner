using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Mailbox.Cleaner.Domain.Data.Documents
{
    public class EmailAddressDocument
    {
        [BsonElement(nameof(Email))]
        [JsonProperty(nameof(Email))]
        public string Email { get; set; }

        [BsonElement(nameof(User))]
        [JsonProperty(nameof(User))]
        public string User { get; set; }

        [BsonElement(nameof(Domain))]
        [JsonProperty(nameof(Domain))]
        public string Domain { get; set; }

        [BsonElement(nameof(RootDomain))]
        [JsonProperty(nameof(RootDomain))]
        public string RootDomain { get; set; }
    }
}
