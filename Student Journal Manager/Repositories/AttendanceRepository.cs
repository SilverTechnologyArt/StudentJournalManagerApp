using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Journal_Manager.Context;
using Student_Journal_Manager.Models;

namespace Student_Journal_Manager.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly MyDbContext _context;

        public AttendanceRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Attendance>> GetAllAttendances()
        {
            return await _context.Attendances.ToListAsync();
        }

        public async Task<Attendance> GetAttendanceById(int id)
        {
            return await _context.Attendances.FindAsync(id);
        }

        public async Task AddAttendance(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAttendance(Attendance attendance)
        {
            _context.Entry(attendance).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAttendance(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveAttendance(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
        }
    }
}
