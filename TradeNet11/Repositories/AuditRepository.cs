using Microsoft.EntityFrameworkCore;
using TradeNet11.Data;
using TradeNet11.Interfaces;
using TradeNet11.Models;

namespace TradeNet11.Repositories
{
    public class AuditRepository : IAuditRepository
    {
        private readonly AppDbContext _context;

        public AuditRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Audit>> GetAllAsync()
        {
            return await _context.Audits
                .Include(a => a.AssignedOfficer)
                .OrderByDescending(a => a.ScheduledDate)
                .ToListAsync();
        }

        public async Task<Audit?> GetByIdAsync(int id)
        {
            return await _context.Audits
                .Include(a => a.AssignedOfficer)
                .Include(a => a.ComplianceCase)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(Audit audit)
        {
            _context.Audits.Add(audit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Audit audit)
        {
            _context.Audits.Update(audit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Audits.FindAsync(id);
            if (entity is not null)
            {
                _context.Audits.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
