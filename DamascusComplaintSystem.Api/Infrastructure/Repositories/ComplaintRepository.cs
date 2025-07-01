using DamascusComplaintSystem.Api.Data;
using DamascusComplaintSystem.Api.Enums;
using DamascusComplaintSystem.Api.Infrastructure.Repositories.Interfaces;
using DamascusComplaintSystem.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DamascusComplaintSystem.Api.Infrastructure.Repositories
{
    public class ComplaintRepository : IComplaintRepository
    {
        private readonly AppDbContext _context;

        public ComplaintRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Complaint complaint)
        {
            if(complaint.Status==0)
            {
                complaint.Status=ComplaintStatus.Received;
            }
              await _context.Complaints.AddAsync(complaint);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var complaint = await _context.Complaints.FindAsync(id);

            if (complaint != null)
            {
                _context.Complaints.Remove(complaint);
                await _context.SaveChangesAsync();
            }

            
        }

        public async Task<IEnumerable<Complaint>> GetAllAsync()
        {
             return await _context.Complaints.ToListAsync();
         }

        public async Task<Complaint?> GetByIdAsync(int id)
        {
            return await _context.Complaints.FindAsync(id);
        }

        public async Task<Complaint?> GetByIdWithComplaintTypeAsync(int id)
        {
            return await _context.Complaints
                .Include(c => c.ComplaintType)
                .FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task Update(Complaint complaint)
        {
            _context.Complaints.Update(complaint);
             _context.SaveChanges();
        }
    }
}
