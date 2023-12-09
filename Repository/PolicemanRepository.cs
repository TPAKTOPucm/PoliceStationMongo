using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PoliceStationMongo.Models;

namespace PoliceStationMongo.Repository
{
    public class PolicemanRepository: IPolicemanRepository
    {
        private readonly IMongoCollection<Policeman> _policemenCollection;
        public PolicemanRepository(IOptions<PoliceDatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _policemenCollection = mongoDatabase.GetCollection<Policeman>(
                databaseSettings.Value.BooksCollectionName);
        }

        public async Task AddPoliceman(Policeman policeman) => await _policemenCollection.InsertOneAsync(policeman);

        public async Task<Policeman> DeletePoliceman(string policemanId) => await _policemenCollection.FindOneAndDeleteAsync(p => p.Id == policemanId);

        public async Task<Policeman> GetPoliceman(string id) => await _policemenCollection.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task<ICollection<Policeman>> GetPolicemen() => await _policemenCollection.Find(_ => true).ToListAsync();

        public async Task<ICollection<Policeman>> GetPolicemen(string firstName, string lastName) => await _policemenCollection.Find(p => p.firstName ==  firstName && p.lastName == lastName).ToListAsync();

        public async Task UpdatePoliceman(Policeman policeman) => await _policemenCollection.ReplaceOneAsync(p => p.Id == policeman.Id, policeman);
    }
}
