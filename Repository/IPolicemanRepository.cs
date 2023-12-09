using PoliceStationMongo.Models;

namespace PoliceStationMongo.Repository
{
    public interface IPolicemanRepository
    {
        Task<ICollection<Policeman>> GetPolicemen();
        Task<ICollection<Policeman>> GetPolicemen(string firstName, string lastName);
        Task<Policeman> GetPoliceman(string id);
        Task AddPoliceman(Policeman policeman);
        Task<Policeman> DeletePoliceman(string policemanId);
        Task UpdatePoliceman(Policeman policeman);
    }
}
