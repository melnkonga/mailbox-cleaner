using System;
using System.Threading.Tasks;
using Mailbox.Cleaner.Domain.Data.Documents;
using Mailbox.Cleaner.Domain.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Mailbox.Cleaner.Domain.Data.Repository
{
    public class ImportReportRepository : IImportReportRepository
    {
        private IMongoCollection<ImportReportDocument> _reportCollection { get; }

        public ImportReportRepository(IMongoClient mongoClient, IOptions<MongoSettings> mongoSettings)
        {
            var settings = mongoSettings.Value ?? throw new ArgumentNullException(nameof(mongoSettings));
            var database = mongoClient.GetDatabase(settings.Database) ?? throw new ArgumentNullException(nameof(mongoClient));
            _reportCollection = database.GetCollection<ImportReportDocument>(settings.CollectionReport);
        }

        public Task<ImportReportDocument> AddOrUpdate(ImportReportDocument document)
        {
            return _reportCollection
                .FindOneAndUpdateAsync<ImportReportDocument>(m => m.Id.Equals(document.Id),
                Builders<ImportReportDocument>.Update.Set(p => p, document),
                new FindOneAndUpdateOptions<ImportReportDocument, ImportReportDocument>
                {
                    IsUpsert = true,
                    ReturnDocument = ReturnDocument.After
                });
        }

        public Task<ImportReportDocument> Complete(string documentId)
        {
            return _reportCollection
                .FindOneAndUpdateAsync<ImportReportDocument>(m => m.Id.Equals(documentId),
                Builders<ImportReportDocument>.Update.Set(p => p.Completed, true),
                new FindOneAndUpdateOptions<ImportReportDocument, ImportReportDocument>
                {
                    IsUpsert = false,
                    ReturnDocument = ReturnDocument.After
                });
        }

        public async Task<ImportReportDocument> Get(string reportId)
        {
            var result = await _reportCollection.FindAsync(report => report.Id.Equals(reportId));
            return result.FirstOrDefault();
        }
    }
}
