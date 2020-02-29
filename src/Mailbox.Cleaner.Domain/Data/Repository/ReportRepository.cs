using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mailbox.Cleaner.Domain.Data.Documents;
using Mailbox.Cleaner.Domain.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Mailbox.Cleaner.Domain.Data.Repository
{
    public class ReportRepository : IReportRepository
    {
        private IMongoCollection<ReportDocument> _reportCollection { get; }

        public ReportRepository(IMongoClient mongoClient, IOptions<MongoSettings> mongoSettings)
        {
            var settings = mongoSettings.Value ?? throw new ArgumentNullException(nameof(mongoSettings));
            var database = mongoClient.GetDatabase(settings.Database) ?? throw new ArgumentNullException(nameof(mongoClient));
            _reportCollection = database.GetCollection<ReportDocument>(settings.CollectionReport);
        }

        public Task Add(ReportDocument document)
        {
            return _reportCollection.InsertOneAsync(document);
        }

        public async Task<ReportDocument> Get(string reportId)
        {
            var result = await _reportCollection.FindAsync(report => report.Id.Equals(reportId));
            return result.FirstOrDefault();
        }

        public async Task<IList<ReportDocument>> Get()
        {
            var result = await _reportCollection.FindAsync(x => x.Id != null);
            return result.ToList();
        }
    }
}
