using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Journal_Manager.Context;
using Student_Journal_Manager.Models;

namespace Student_Journal_Manager.Repositories
{
    public class GuardianRepository : IGuardianRepository
    {
        private readonly MyDbContext _context;

        public GuardianRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Guardian>> GetAllGuardians()
        {
            return await _context.Guardians.ToListAsync();
        }

        public async Task<Guardian> GetGuardianById(int id)
        {
            return await _context.Guardians.FindAsync(id);
        }

        public async Task AddGuardian(Guardian guardian)
        {
            _context.Guardians.Add(guardian);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGuardian(Guardian guardian)
        {
            _context.Entry(guardian).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGuardian(int id)
        {
            var guardian = await _context.Guardians.FindAsync(id);
            if (guardian != null)
            {
                _context.Guardians.Remove(guardian);
                await _context.SaveChangesAsync();
            }
        }
    }
}