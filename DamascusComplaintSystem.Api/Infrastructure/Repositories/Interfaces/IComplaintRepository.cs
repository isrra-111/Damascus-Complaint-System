using DamascusComplaintSystem.Api.Models;

namespace DamascusComplaintSystem.Api.Infrastructure.Repositories.Interfaces
{
    public interface IComplaintRepository
    {
        Task<IEnumerable<Complaint>> GetAllAsync();
        Task<Complaint?> GetByIdAsync(int id);
        Task<Complaint?> GetByIdWithComplaintTypeAsync(int id);
        Task AddAsync(Complaint complaint);
        Task Update(Complaint complaint);
        Task Delete(int id);
    }
}
