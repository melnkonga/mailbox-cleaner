using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mailbox.Cleaner.Domain.Data.Documents
{
    public class DocumentBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
