using ms_documents.Configurations;
using ms_documents.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ms_documents.Repository
{

    public class DocumentRepository : IRepository<Document>
    {
        private readonly IMongoCollection<Document> _collection;

        public DocumentRepository(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            this._collection = mongoDb.GetCollection<Document>(databaseSettings.Value.CollectionName); 
        }

        public async Task CreateAsync(Document entity) => await _collection.InsertOneAsync(entity);


        public async Task DeleteAsync(string id) => await _collection.DeleteOneAsync(id);

        public async Task<IEnumerable<Document>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<Document> GetByIdAsync(string id) => await _collection.Find(d => d.id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(string id, Document entity) => await _collection.ReplaceOneAsync(x => x.id == entity.id, entity);
    }
}
