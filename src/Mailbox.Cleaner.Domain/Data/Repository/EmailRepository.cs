using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mailbox.Cleaner.Domain.Data.Documents;
using Mailbox.Cleaner.Domain.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Mailbox.Cleaner.Domain.Data.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private IMongoCollection<EmailDocument> _emailCollection { get; }
        private readonly MongoSettings _mongoSettings;

        public EmailRepository(IMongoClient mongoClient, IOptions<MongoSettings> mongoSettings)
        {
            _mongoSettings = mongoSettings.Value ?? throw new ArgumentNullException(nameof(mongoSettings));
            var database = mongoClient.GetDatabase(_mongoSettings.Database) ?? throw new ArgumentNullException(nameof(mongoClient));
            _emailCollection = database.GetCollection<EmailDocument>(_mongoSettings.CollectionEmail);
        }

        public async Task<IDictionary<string, int>> GetUniqueDomain(string emailOwner)
        {
            var result = new Dictionary<string, int>();

            using var cursor = await _emailCollection.FindAsync(x => x.To.Email.Equals(emailOwner), new FindOptions<EmailDocument>
            {
                BatchSize = _mongoSettings.BatchSize
            });

            await cursor.ForEachAsync(email =>
            {
                if (!result.TryAdd(email.From.RootDomain, 1))
                {
                    result[email.From.RootDomain]++;
                }
            });

            return result;
        }

        public Task Add(EmailDocument document)
        {
            return _emailCollection.InsertOneAsync(document);
        }
    }
}
